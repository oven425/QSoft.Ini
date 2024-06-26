﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QSoft.Ini
{
    public enum IniTokenType
    {
        None,
        Section,
        Commet,
        PropertyName,
        Value
    }

    public class IniWriter(Stream stream)
    {
        StreamWriter m_SW = new StreamWriter(stream);
        public void WriteSection(string data)
        {
            m_SW.WriteLine($"[{data}]"); 
        }
        public void WritePorpertyName(string data)
        {
            m_SW.WriteLine($"data=");
        }

        public void WriteValue(string data)
        {
            m_SW.WriteLine($"{data}");
        }
    }

    public class IniReader(Stream stream)
    {
        readonly StreamReader m_Reader = new(stream);


        Regex regex_section = new(@"^\[(?<section>\w+)\]$");
        Regex regex_keyvalue = new(@"^(?<key>\w+)=(?<value>.*)$");
        public IniTokenType TokenType { get; private set; }
        public string GetString()
        {
            var aa = this.TokenType switch
            {
                IniTokenType.Section => this.m_Section,
                IniTokenType.PropertyName => this.m_PropertyName,
                IniTokenType.Value => this.m_PropertyValue,
                _ => ""
            };
            return aa;
        }

        public bool Read()
        {
            if (TokenType == IniTokenType.PropertyName && m_PropertyValue != null)
            {
                TokenType = IniTokenType.Value;
                return true;
            }
            var line = m_Reader.ReadLine();
            if (line == null) return false;

            TokenType = IniTokenType.None;
            var match_section = regex_section.Match(line);
            if (match_section.Success)
            {
                TokenType = IniTokenType.Section;
                m_Section = match_section.Groups["section"].Value;
            }
            if(TokenType == IniTokenType.None)
            {
                var match_kv = regex_keyvalue.Match(line);
                if (match_kv.Success)
                {
                    TokenType = IniTokenType.PropertyName;
                    m_PropertyName = match_kv.Groups["key"].Value;
                    m_PropertyValue = match_kv.Groups["value"].Value;
                }
            }
            

            return true;
        }

        string m_Section;
        string m_PropertyName;
        string m_PropertyValue;

    }

    public static class IniReaderExtension
    {
        public static int ReadInt32(this IniReader src)
        {
            int.TryParse(src.GetString(), out var val);
            return val;
        }
    }
}
