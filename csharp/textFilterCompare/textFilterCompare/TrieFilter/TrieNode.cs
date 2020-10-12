using System;
using System.Collections.Generic;
using System.Text;

namespace textFilterCompare
{
    public class TrieNode
    {
        public bool m_end;
        public Dictionary<char, TrieNode> m_values;
        public TrieNode()
        {
            m_values = new Dictionary<char, TrieNode>();
        }

        public bool TryGetValue(char c, out TrieNode node)
        {
            return m_values.TryGetValue(c, out node);
        }

        public TrieNode Add(char c)
        {
            TrieNode subnode;
            if (!m_values.TryGetValue(c, out subnode))
            {
                subnode = new TrieNode();
                m_values.Add(c, subnode);
            }
            return subnode;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            toString(sb);
            return sb.ToString();
        }
        private void toString(StringBuilder sb)
        {
            var index = 0;
            if (m_values.Count == 0) return;
            if (m_values.Count == 1)
            {
                foreach (var item in m_values)
                {
                    AddString(sb, item.Key);
                    item.Value.toString(sb);
                }
                return;
            }

            sb.Append("(");
            foreach (var item in m_values)
            {
                if (index > 0)
                {
                    sb.Append("|");
                }
                AddString(sb, item.Key);
                item.Value.toString(sb);
                index++;
            }
            sb.Append(")");
        }
        private void AddString(StringBuilder sb, char item)
        {
            if (item == '(')
            {
                sb.Append(@"\(");
            }
            else if (item == '.')
            {
                sb.Append(@"\.");
            }
            else if (item == '*')
            {
                sb.Append(@"\*");
            }
            else if (item == '+')
            {
                sb.Append(@"\+");
            }
            else if (item == ')')
            {
                sb.Append(@"\)");
            }
            else if (item == '\\')
            {
                sb.Append(@"\\");
            }
            else if (item == '[')
            {
                sb.Append(@"\[");
            }
            else if (item == ']')
            {
                sb.Append(@"\]");
            }
            else if (item == '{')
            {
                sb.Append(@"\{");
            }
            else if (item == '}')
            {
                sb.Append(@"\}");
            }
            else if (item == '^')
            {
                sb.Append(@"\^");
            }
            else if (item == '$')
            {
                sb.Append(@"\$");
            }
            else if (item == '?')
            {
                sb.Append(@"\?");
            }
            else
            {
                sb.Append(item);
            }
        }

    }

}
