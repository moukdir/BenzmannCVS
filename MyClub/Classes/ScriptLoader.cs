using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Configuration;

namespace MyClub.Classes
{
    public static class ScriptLoader
    {
        private static Dictionary<string, string> supportedStripts = new Dictionary<string, string>()
        {
            /* CSS Files */
            //{"styles.css", CreateLinkTag("/Content/Framework/theme/styles.css") },
            {"jquery.lightbox.css", CreateLinkTag("/Content/jquery/lightbox/jquery.lightbox.css") },
            {"yaml.base.css", CreateLinkTag("/Content/yaml/core/base.css") },
            {"yaml.iehacks.css", CreateLinkTag("/Content/yaml/core/iehacks.css") },
            {"yaml.layout.css", CreateLinkTag("/Content/yaml/layout.css") },

            /* Javascripts Files */
            {"jquery.js", CreateScriptTag("/Content/jquery/jquery.js") },
            {"jquery.form.js", CreateScriptTag("/Content/jquery/jquery.validate/lib/jquery.form.js") },
            {"jquery.metadata.js", CreateScriptTag("/Content/jquery/jquery.validate/lib/jquery.metadata.js") },
            {"jquery.validate.js", CreateScriptTag("/Content/jquery/jquery.validate/jquery.validate.js") },
            {"additional-methods.js", CreateScriptTag("/Content/jquery/jquery.validate/additional-methods.js") },
            {"jquery.lightbox.js", CreateScriptTag("/Content/jquery/lightbox/jquery.lightbox.js") },
            {"xVal.jquery.validate.js", CreateScriptTag("/Content/xVal/xVal.jquery.validate.js") }
        };
        private static Dictionary<string, List<string>> supportedComponents = new Dictionary<string, List<string>>
        {
            { "xVal", new List<string> { "jquery", "jquery.validate", "xVal.jquery.validate.js" } },
            { "jquery.validate", new List<string> { "jquery.form.js", "jquery.metadata.js", "jquery.validate.js", "additional-methods.js" } },
            { "jquery", new List<string> { "jquery.js" } },
            { "lightbox", new List<string> { "jquery.lightbox.js", "jquery.lightbox.css" } },
            { "yaml", new List<string> { "yaml.base.css", "yaml.iehacks.css", "yaml.layout.css" } }
        };

        public static string Load(string[] components) {
            Dictionary<string, string> elements = new Dictionary<string, string>();
            foreach (string element in components)
            {
                if (supportedComponents.ContainsKey(element))
                {
                    foreach (string script in supportedComponents[element])
                    {
                        if (supportedStripts.ContainsKey(script))
                        {
                            try
                            {
                                elements.Add(script, supportedStripts[script]);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            if (supportedComponents.ContainsKey(script))
                            {
                                foreach (string componentScript in supportedComponents[script])
                                {
                                    if (supportedStripts.ContainsKey(componentScript))
                                    {
                                        try
                                        {
                                            elements.Add(componentScript, supportedStripts[componentScript]);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("ScriptLoader->WriteCssSCriptTags() - Script: " + componentScript + " doesn't exist in component: " + script + ".");
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("ScriptLoader->WriteCssSCriptTags() - Script: " + script + " doesn't exist.");
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("ScriptLoader->WriteCssSCriptTags() - Component: " + element + " doesn't exist.");
                }
            }
            StringBuilder builder = new StringBuilder(500);
            foreach (KeyValuePair<string,string> keyValue in elements) {
                builder.AppendLine(keyValue.Value);
            }
            return builder.ToString();
        }

        private static string CreateScriptTag(string url) 
        {
            TagBuilder builder = new TagBuilder("script");
            builder.MergeAttribute("type", "text/javascript");
            builder.MergeAttribute("src", url);

            // Render tag
            return builder.ToString(TagRenderMode.Normal);
        }
        private static string CreateLinkTag(string url) 
        {
            TagBuilder builder = new TagBuilder("link");
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");
            builder.MergeAttribute("href", url);

            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}