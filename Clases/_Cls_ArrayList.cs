using System;
using System.Collections.Generic;
using System.Text;

namespace T3.Clases
{
    public class _Cls_ArrayList
    {
        private string m_Display;
        private string m_Value;
        public _Cls_ArrayList(string Display, string Value)
        {
            m_Display = Display;
            m_Value = Value;
        }
        public string Display
        {
            get{return m_Display;}
        }
        public string Value
        {
            get{return m_Value;}
        }
    }
}
