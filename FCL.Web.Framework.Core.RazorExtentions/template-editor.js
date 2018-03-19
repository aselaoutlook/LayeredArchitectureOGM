<script type="text/javascript">$(document).ready(function() {{ $('#{0}').summernote({{ 
    width:{1},
    height:{2},
    minHeight: {3},
    maxHeight: {4},
    templateEditor:{5},
    parserRegEx:"{6}",
    focus: true,
    toolbar: [
        ['style', ['bold', 'italic', 'underline', 'clear']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['fontsize', ['fontsize']],
        ['color', ['color']],
        ['para', ['ul', 'ol', 'paragraph']],
        ['template', ['tags', 'savetemplate', 'resettemplate']]
    ],
    onInit: function (e) {{
        {7}
    }},
    onSave: function (data) {{
        {8}
    }},
    onReset: function (e) {{
        {9}
    }}
}});
}});
</script>