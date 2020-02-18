using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VxLoadMenu
{
    public class CVxParsor
    {
        public static String VxGetTodayMenu()
        {
            String strTodayMenu = String.Empty;

            try
            {
                var timeoutInMilliseconds = 5000;
                var uri = new Uri("http://mini.snu.kr/cafe/today/");
                var doc = Supremes.Dcsoup.Parse(uri, timeoutInMilliseconds);

                var menuDiv = doc.Select("div#main.br_menu2");
                var menuName = menuDiv.Select("td");

                int iIndex = 0;

                for (int i = 0; i < menuName.Count; i++)
                {
                    if (menuName[i].ToString().Contains(@"/cafe/miniinfo/w"))
                    {
                        iIndex = i;
                        break;
                    }
                }
                strTodayMenu = Regex.Replace(menuName[iIndex + 1].ToString(), "<[^>]*>", "\n").Replace("&amp;", ",");
                strTodayMenu = strTodayMenu.Replace("45", "4,500");
                strTodayMenu = strTodayMenu.Replace("50", "5,000");
                strTodayMenu = strTodayMenu.Replace("55", "5,500");
                strTodayMenu = strTodayMenu.Replace("\n\n", "\n");

                
                //System.Windows.MessageBox.Show(strTodayMenu);
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show("ERROR : " + e.Message);
            }

            return strTodayMenu;
        }
    }
}
