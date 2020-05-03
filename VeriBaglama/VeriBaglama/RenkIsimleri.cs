using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace VeriBaglama
{
    public class RenkIsimleri
    {
        public RenkIsimleri()
        {

        }

        public string RenkAdi { private set; get; }

        public string BilinenIsim { private set; get; }

        public Color Renk { private set; get; }

        // Static members.
        static RenkIsimleri()
        {
            List<RenkIsimleri> butunRenkler = new List<RenkIsimleri>();
            StringBuilder metinTasarlayici = new StringBuilder();

            // Loop through the public static fields of the Color structure.
            foreach (FieldInfo alanBilgisi in typeof(Color).GetRuntimeFields())
            {
                if (alanBilgisi.IsPublic &&
                    alanBilgisi.IsStatic &&
                    alanBilgisi.FieldType == typeof(Color))
                {
                    // Convert the name to a friendly name.
                    string name = alanBilgisi.Name;
                    metinTasarlayici.Clear();
                    int index = 0;

                    foreach (char ch in name)
                    {
                        if (index != 0 && Char.IsUpper(ch))
                        {
                            metinTasarlayici.Append(' ');
                        }
                        metinTasarlayici.Append(ch);
                        index++;
                    }

                    // Instantiate a NamedColor object.
                    RenkIsimleri renkIsimleri = new RenkIsimleri
                    {
                        RenkAdi = name,
                        BilinenIsim = metinTasarlayici.ToString(),
                        Renk = (Color)alanBilgisi.GetValue(null)
                    };

                    // Add it to the collection.
                    butunRenkler.Add(renkIsimleri);
                }
            }
            butunRenkler.TrimExcess();
            ButunRenkler = butunRenkler;
        }

        public static IEnumerable<RenkIsimleri> ButunRenkler { private set; get; }
    }
}
