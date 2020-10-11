namespace CardMarket.Api.Structs
{
    public struct Language
    {
        private readonly string name;

        private readonly int id;

        public override string ToString()
        {
            return name;
        }

        private Language(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static Language English
        {
            get { return new Language(1, "English"); }
        }

        public static Language French
        {
            get { return new Language(2, "French"); }
        }

        public static Language German
        {
            get { return new Language(3, "German"); }
        }

        public static Language Spanish
        {
            get { return new Language(4, "Spanish"); }
        }

        public static Language Italian
        {
            get { return new Language(5, "Italian"); }
        }

        public static Language SimplifiedChinese
        {
            get { return new Language(6, "Simplified Chinese"); }
        }

        public static Language Japanese
        {
            get { return new Language(7, "Japanese"); }
        }

        public static Language Portuguese
        {
            get { return new Language(8, "Portuguese"); }
        }

        public static Language Russian
        {
            get { return new Language(9, "Russian"); }
        }

        public static Language Korean
        {
            get { return new Language(10, "Korean"); }
        }

        public static Language TraditionalChinese
        {
            get { return new Language(11, "Traditional Chinese"); }
        }

        public static Language FromId(int id)
        {
            var properties = typeof(Language).GetProperties();

            for(int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(Language))
                {
                    var lang = (Language)properties[i].GetValue(null);
                    if (lang.id == id)
                        return lang;
                }
            }

            return English;
        }
    }
}
