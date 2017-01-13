// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
(function ($) {
    $.fn.verifyCode = function (options) {
        if (arguments.length > 0 && typeof arguments[0] == 'string') {
            if (arguments[0] == 'validate') {
                var isValid = false;
                var p = $(this[0]).data('options');
                var jkey = $(this[0]).attr('jkey');
                var code = arguments[1];
                var url = p.validateUrl;
                var par = 'key=' + jkey + '&code=' + code;
                if (url.indexOf('?') == -1) {
                    url += '?' + par;
                }
                else {
                    url += '&' + par;
                }

                $.ajax({
                    url: url,
                    async: false,
                    type: 'get',
                    dataType: 'json',
                    success: function (result) {
                        isValid = result;
                    }
                })

                return isValid;
            }

            return;
        }

        options = $.extend({
            url: '',
            validateUrl: '',
            length: 4
        }, options);

        return new $._verifyCode(this, options);
    }

    $._verifyCode = function (elements, options) {
        var self = this;

        $.extend(this, {
            refresh: function (ele) {
                var par = 'width=' + ele.width() + '&height=' + ele.height() + '&key=' + ele.attr('jkey') + '&r=' + Math.random();
                var url = options.url;
                if (url.indexOf('?') == -1) {
                    url += '?' + par;
                }
                else {
                    url += '&' + par;
                }
                ele.attr('src', url);
            }
        })

        elements.each(function (index, e) {
            var ele = $(e);
            if (e.tagName == 'IMG') {
                var rnd = Math.random();
                ele.data('options', options)
                    .attr('jkey', rnd).css('cursor', 'pointer').click(function () {
                        self.refresh(ele);
                    });
                self.refresh(ele);
            }
        });
    }
})(jQuery);