namespace RyanPenfold.Utilities.Xml
{
    public static class XmlNodeList
    {
        public static bool Any(this System.Xml.XmlNodeList input, System.Func<System.Xml.XmlElement, bool> predicate = null)
        {
            if (input == null)
                throw new System.ArgumentNullException(nameof(input));

            if (predicate == null)
                return input.Count > 0;

            var rtn = false;

            foreach (System.Xml.XmlElement element in input)
                rtn = rtn || predicate(element);

            return rtn;
        }
    }
}
