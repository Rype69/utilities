namespace RyanPenfold.Utilities.Xml
{
    public static class XmlAttributeCollection
    {
        public static bool Any(this System.Xml.XmlAttributeCollection input, System.Func<System.Xml.XmlAttribute, bool> predicate = null)
        {
            if (input == null)
                throw new System.ArgumentNullException(nameof(input));

            if (predicate == null)
                return input.Count > 0;

            var rtn = false;

            foreach (System.Xml.XmlAttribute attribute in input)
                rtn = rtn || predicate(attribute);

            return rtn;
        }
    }
}