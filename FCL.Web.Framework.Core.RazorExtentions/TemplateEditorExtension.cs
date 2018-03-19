using System;
using System.Web.Mvc;

namespace FCL.Web.Framework.Core.RazorExtentions
{


    #region MvcHtmlTableExtension

    /// <summary>
    /// Methods that needs to be implemented by TemplateEditor
    /// </summary>
    public interface IEMailTemplateEditorBuilder
    {
        TempalteEditor EditorId(string id);
        TempalteEditor EditorClasses(string classes);
        TempalteEditor Height(int? height);
        TempalteEditor Width(int? width);
        TempalteEditor EditorMinHeight(int? height);
        TempalteEditor EditorMaxHeight(int? height);
        TempalteEditor IsTemplateEditor(bool enabled);
        TempalteEditor TagRegxp(string regExp);
        TempalteEditor InitTemplateCallback(string function);
        TempalteEditor SaveTemplateCallback(string function);
        TempalteEditor ResetTemplateCallback(string function);
    }

    /// <summary>
    /// Renders a rich-text editor that can be used to format tagged html syntax.
    /// Ex:- If you use email templates in your project which uses Posta.net, you can provide this plugin
    /// to let your customers to modify the templates visually.
    /// Note:
    /// 1) This uses a customized summernote editor (summernote.org) in ~/Scripts folder
    /// 2) This needs Bootstrap version 3.0.0 or above and loaded BEFORE summernote script
    /// </summary>
    public class TempalteEditor : IEMailTemplateEditorBuilder
    {
        private HtmlHelper HtmlHelper { get; set; }
        private string editorId { get; set; }
        private string editorClasses { get; set; }
        private int? height { get; set; }
        private int? width { get; set; }
        private bool isTemplateEditor { get; set; }
        private string tagRegxp { get; set; }
        private int? minHeight { get; set; }
        private int? maxHeight { get; set; }
        private string initCallback { get; set; }
        private string saveCallback { get; set; }
        private string resetCallback { get; set; }

        private TempalteEditor()
        {
        }

        internal TempalteEditor(HtmlHelper helper)
        {
            HtmlHelper = helper;
            EditorId("template-editor");
            IsTemplateEditor(true);
            TagRegxp("@View\\w+.\\w+");
            EditorMinHeight(300);
            EditorMaxHeight(500);
        }

        /// <summary>
        /// Set's the id of editor that will be used by javascripts
        /// </summary>
        /// <param name="id">Id of the editor div</param>
        /// <returns></returns>
        public TempalteEditor EditorId(string id)
        {
            editorId = id;
            return this;
        }

        /// <summary>
        /// Set any classes that needs to customize look & feel etc...
        /// </summary>
        /// <param name="classes">class names seperated by space</param>
        /// <returns></returns>
        public TempalteEditor EditorClasses(string classes)
        {
            editorClasses = classes;
            return this;
        }

        /// <summary>
        /// Set the minimum height of the editor area. Defaults to 300px
        /// Max height is based on the content size
        /// </summary>
        /// <param name="heightPx">Height in pixels</param>
        /// <returns></returns>
        public TempalteEditor EditorMinHeight(int? heightPx)
        {
            minHeight = heightPx;
            return this;
        }

        /// <summary>
        /// Set the maximum height of the editor area. Defaults to 500px
        /// </summary>
        /// <param name="heightPx">Height in pixels</param>
        /// <returns></returns>
        public TempalteEditor EditorMaxHeight(int? heightPx)
        {
            maxHeight = heightPx;
            return this;
        }

        /// <summary>
        /// Set height of the editor
        /// </summary>
        /// <param name="height">editor height</param>
        /// <returns></returns>
        public TempalteEditor Height(int? height)
        {
            this.height = height;
            return this;
        }

        /// <summary>
        /// set width of editor
        /// </summary>
        /// <param name="width">editor width</param>
        /// <returns></returns>
        public TempalteEditor Width(int? width)
        {
            this.width = width;
            return this;
        }

        /// <summary>
        /// Set whether the editor to be rendered as a template editor. Otherwise it'll be rendered as a generic richtext editor
        /// </summary>
        /// <param name="enabled">enabled if true</param>
        /// <returns></returns>
        public TempalteEditor IsTemplateEditor(bool enabled)
        {
            isTemplateEditor = enabled;
            return this;
        }

        /// <summary>
        /// Template editor will use the given regular expression to parse the content. RegEx must work in javascript
        /// Defaults to "@View\\w+.\\w+" which matches tags like @ViewBag.PropertyName
        /// Matches will then be converted to tags within the editor
        /// </summary>
        /// <param name="regExp">Valid regular expression</param>
        /// <returns></returns>
        public TempalteEditor TagRegxp(string regExp)
        {
            tagRegxp = regExp;
            return this;
        }

        /// <summary>
        /// call back scripts to run on initialize
        /// </summary>
        /// <param name="function">Any valid javascript string.</param>
        /// <returns></returns>
        public TempalteEditor InitTemplateCallback(string function)
        {
            initCallback = function;
            return this;
        }

        /// <summary>
        /// Set the javascript function which gets called when Save Template is clicked.
        /// </summary>
        /// <param name="function">Any valid javascript string.</param>
        /// <returns></returns>
        public TempalteEditor SaveTemplateCallback(string function)
        {
            saveCallback = function;
            return this;
        }

        /// <summary>
        /// Set the javascript function which gets called when reset Template is clicked.
        /// </summary>
        /// <param name="function">Any valid javascript string.</param>
        /// <returns></returns>
        public TempalteEditor ResetTemplateCallback(string function)
        {
            resetCallback = function;
            return this;
        }

        /// <summary>
        /// Convert the Summernote syntax to HTML for rendering.
        /// </summary>
        public MvcHtmlString ToHtml()
        {
            var editorSyntax = String.Format("<div id=\"{0}\" class=\"{1}\"></div>",editorId,editorClasses);

            var script = TemplateEditorScript.template_editor;
            var test = String.Format(script, 
                editorId, 
                ParseNullable(width), 
                ParseNullable(height), 
                ParseNullable(minHeight), 
                ParseNullable(maxHeight), 
                isTemplateEditor? "true" : "false", 
                tagRegxp,
                initCallback, 
                saveCallback, 
                resetCallback);

            return new MvcHtmlString(String.Format("{0}\r\n{1}", editorSyntax, test));
        }

        private string ParseNullable(int? value)
        {
            if (value.HasValue)
                return value.ToString();
            else
                return "null";

        }
    }

    public static class TemplateEditorExtension
    {
        /// <summary>
        /// Return an instance the editor.
        /// </summary>
        /// <returns>Instance of a TableBuilder.</returns>
        public static IEMailTemplateEditorBuilder TemplateEditorFor(this HtmlHelper helper)
        {
            return new TempalteEditor(helper);
        }
    }
    #endregion MvcHtmlTableExtension
}
