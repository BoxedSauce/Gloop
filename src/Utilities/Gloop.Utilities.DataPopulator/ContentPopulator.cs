using System.Collections.Generic;
using Gloop.Core;
using Gloop.Core.Pages;

namespace Gloop.Utilities.DataPopulator
{
    internal class ContentPopulator
    {
        private readonly ApplicationContext _application;

        public ContentPopulator(ApplicationContext application)
        {
            _application = application;
        }

        public void Populate()
        {
            var homePage = new GloopPageData
            {
                Name = "Home",
                Url = "/",
                ViewName = "Home",
                Fields = new Dictionary<string, string>
                {
                    {"title","Gloop Home"},
                    {"body", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pulvinar bibendum est, ut congue neque mattis faucibus. Sed ac augue lectus. Duis cursus imperdiet pulvinar. Vestibulum in hendrerit lectus, at imperdiet ipsum. Maecenas rutrum semper magna lacinia faucibus. Donec varius ornare urna, ac porttitor nisi tristique ac. Nunc et turpis pharetra, varius velit quis, elementum nibh. Pellentesque convallis mattis nunc id dictum. Vivamus vel nibh dignissim, malesuada massa ut, eleifend metus. Proin sed aliquam quam, eu interdum purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ut lacus non ex dictum porta vitae et nisl.</p><p>Mauris vel tempus dui. Proin ut quam erat. Praesent mattis a enim sit amet pellentesque. Donec maximus euismod urna eget pulvinar. Morbi ut molestie tellus. Duis pellentesque id eros semper vehicula. Vivamus auctor pharetra lorem, et euismod erat feugiat in. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam suscipit efficitur eros, sodales gravida tortor tempus a. Donec pulvinar mauris vel odio vulputate vulputate.</p>"}
                }
            };

            var aboutPage = new GloopPageData
            {
                Name = "About",
                Url = "/about",
                ViewName = "About",
                Fields = new Dictionary<string, string>
                {
                    {"title","About Gloop"},
                    {"body", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pulvinar bibendum est, ut congue neque mattis faucibus. Sed ac augue lectus. Duis cursus imperdiet pulvinar. Vestibulum in hendrerit lectus, at imperdiet ipsum. Maecenas rutrum semper magna lacinia faucibus. Donec varius ornare urna, ac porttitor nisi tristique ac. Nunc et turpis pharetra, varius velit quis, elementum nibh. Pellentesque convallis mattis nunc id dictum. Vivamus vel nibh dignissim, malesuada massa ut, eleifend metus. Proin sed aliquam quam, eu interdum purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ut lacus non ex dictum porta vitae et nisl.</p><p>Mauris vel tempus dui. Proin ut quam erat. Praesent mattis a enim sit amet pellentesque. Donec maximus euismod urna eget pulvinar. Morbi ut molestie tellus. Duis pellentesque id eros semper vehicula. Vivamus auctor pharetra lorem, et euismod erat feugiat in. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam suscipit efficitur eros, sodales gravida tortor tempus a. Donec pulvinar mauris vel odio vulputate vulputate.</p>"}
                }
            };

            _application.ContentService.SavePage(homePage);
            _application.ContentService.SavePage(aboutPage);
        }
    }
}
