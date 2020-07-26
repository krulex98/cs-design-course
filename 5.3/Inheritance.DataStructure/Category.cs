using System;

namespace Inheritance.DataStructure
{
    public class Category: IComparable
    {
        private readonly string _name;
        private readonly MessageType _messageType;
        private readonly MessageTopic _messageTopic;
        
        public Category(string name, MessageType type, MessageTopic topic)
        {
            _name = name;
            _messageType = type;
            _messageTopic = topic;
        }
        
        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is Category category)) 
                return 1;

            var c1 = this;
            var c2 = category;
            var nameCompare = string.Compare(c1._name, c2._name, StringComparison.OrdinalIgnoreCase);

            if (nameCompare < 0)
                return -1;

            if (nameCompare == 0)
            {
                if (c1._messageType < c2._messageType)
                {
                    return -1;
                }
                
                if (c1._messageType == c2._messageType)
                {
                    if (c1._messageTopic < c2._messageTopic)
                        return -1;

                    if (c1._messageTopic == c2._messageTopic)
                        return 0;
                        
                    if (c1._messageTopic > c2._messageTopic)
                        return 1;
                }
                else
                {
                    return 1;
                }
            }

            return 1;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() * ((int)_messageType + 1) * ((int)_messageTopic + 5);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Category category))
                return false;

            return CompareTo(category) == 0;
        }

        public static bool operator <(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == -1;
        }
        
        public static bool operator >(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == 1;
        }
        
        public static bool operator <=(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == -1 || c1.CompareTo(c2) == 0;
        }
        
        public static bool operator >=(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == 0 || c1.CompareTo(c2) == 1;
        }
        
        public static bool operator ==(Category c1, Category c2)
        {
            return c1.Equals(c2);
        }
        
        public static bool operator !=(Category c1, Category c2)
        {
            return !c1.Equals(c2);
        }

        public override string ToString()
        {
            return $"{_name}.{_messageType}.{_messageTopic}";
        }
    }
}
