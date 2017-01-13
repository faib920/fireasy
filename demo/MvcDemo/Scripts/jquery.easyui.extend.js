//对 form 的扩展
$.extend($.fn.form.methods, {
    //将窗体上的数据填充到 model
    save: function (jq, g) {
        var data = new Object();
        $('[name]', jq).each(function (i, o) {
            var name = $(o).attr('name');
            if (!_saveCheck(name, data)) {
                if (!_saveOther(name, data)) {
                    _saveCombo(name, data);
                }
            }
        });

        function _saveCheck(name, data) {
            var rr = $(jq).find('input[name="' + name + '"][type=radio], input[name="' + name + '"][type=checkbox]');
            if (rr.length == 1) {
                data[name] = rr.prop('checked') ? 1 : 0;
                return true;
            }
            return false;
        }

        function _saveOther(name, data) {
            var pp = ['textbox', 'numberbox', 'slider'];
            for (var i = 0; i < pp.length; i++) {
                var p = pp[i];
                var f = $(jq).find('input[' + p + 'Name="' + name + '"],textarea[' + p + 'Name="' + name + '"]');
                if (f.length) {
                    data[name] = f[p]('getValue');
                    return f.length;
                }
            }
            return 0;
        }

        function _saveCombo(name, data) {
            var cc = ['combobox', 'combotree', 'combogrid', 'datetimebox', 'datebox', 'combo'];
            var c = $(jq).find('[comboName="' + name + '"]');
            if (c.length) {
                for (var i = 0; i < cc.length; i++) {
                    var type = cc[i];
                    if (c.hasClass(type + '-f')) {
                        if (c[type]('options').multiple) {
                            data[name] = c[type]('getValues');
                        } else {
                            data[name] = c[type]('getValue');
                        }
                        return;
                    }
                }
            }
        }

        return data;
    },
    saveData: function (jq, url, opts) {
        if (!jq.form('validate')) {
            return '';
        }

        opts = $.extend(opts, { isNew: false, fill: function (data, postData) { }, success: function (id, result) { } });

        var postData = new Object();

        //将表单填充的内容序列化为json
        var data = jq.form('save');
        opts.fill.call(data, postData);
        postData['info'] = JSON.stringify(data);

        common.showProcess();
        $.post(url, postData, function (result) {
            common.processResult(result, function () {
                if (opts.isNew) {
                    jq.form('clear');
                }

                var id = isNew ? '' : result.data;
                common.setReturnValue(true);
                opts.success.call(id, result);
            });
        });
    },
    //将 model 中的数据显示到窗体
    load: function (jq, data) {
        for (var name in data) {
            var form = $(jq);
            var val = data[name];
            var rr = _loadCheck(name, val);
            if (!rr.length) {
                var count = _loadOther(name, val);
                if (!count) {
                    $('input[name="' + name + '"]', form).val(val);
                    $('textarea[name="' + name + '"]', form).val(val);
                    $('select[name="' + name + '"]', form).val(val);
                    if (typeof val == 'string') {
                        $('span[name="' + name + '"]', form).html(val.replace(/\n/g, '<br/>'));
                    }
                }
            }
            _loadCombo(name, val);
            var opts = $.data(jq[0], 'form').options;
            opts.onLoadSuccess.call(jq, data);
            jq.form('validate', jq);
        }

        function _loadCheck(name, val) {
            var rr = $(jq).find('input[name="' + name + '"][type=radio], input[name="' + name + '"][type=checkbox]');
            rr.prop('checked', false);
            rr.each(function () {
                var f = $(this);
                if (val == 1 || val == true || val == '1' || f.val() == String(val) || $.inArray(f.val(), $.isArray(val) ? val : [val]) >= 0) {
                    f.prop('checked', true);
                }
            });
            return rr;
        }

        function _loadOther(name, val) {
            var pp = ['textbox', 'numberbox', 'slider'];
            for (var i = 0; i < pp.length; i++) {
                var p = pp[i];
                var f = $(jq).find('input[' + p + 'Name="' + name + '"],textarea[' + p + 'Name="' + name + '"]');
                if (f.length) {
                    f[p]('setValue', val);
                    return f.length;
                }
            }
            return 0;
        }

        function _loadCombo(name, val) {
            var cc = ['combobox', 'combotree', 'combogrid', 'datetimebox', 'datebox', 'combo'];
            var c = $(jq).find('[comboName="' + name + '"]');
            if (c.length) {
                for (var i = 0; i < cc.length; i++) {
                    var type = cc[i];
                    if (c.hasClass(type + '-f')) {
                        if (c.attr('delay')) {
                            c.attr('_value', val);
                        }
                        else if (c[type]('options').multiple) {
                            c[type]('setValues', val);
                        } else {
                            c[type]('setValue', val);
                        }
                        return;
                    }
                }
            }
        }
    },
    loadData: function (jq, url, opts) {
        opts = $.extend(opts, { id: '', success: function () { } });
        if (opts.id != '') {
            jq.data('id', opts.id);
            $.getJSON(url, function (result) {
                common.processResult(result, function () {
                    jq.form('load', result);
                    opts.success.call(result);
                });
            });
        }
    },
    clear: function (jq) {
        $('[name]', jq).each(function (i, o) {
            var name = $(o).attr('name');
            if (!_clearCheck(name)) {
                if (!_clearOther(name)) {
                    _clearCombo(name);
                }
            }
        });


        function _clearCheck(name) {
            var rr = $(jq).find('input[name="' + name + '"][type=radio], input[name="' + name + '"][type=checkbox]');
            if (rr.length == 1) {
                if (!rr.attr('noclear')) {
                    rr.prop('checked', false);
                }
                return true;
            }
            return false;
        }

        function _clearOther(name) {
            var pp = ['textbox', 'numberbox', 'slider'];
            for (var i = 0; i < pp.length; i++) {
                var p = pp[i];
                var f = $(jq).find('input[' + p + 'Name="' + name + '"],textarea[' + p + 'Name="' + name + '"]');
                if (f.length && !f.attr('noclear')) {
                    f[p]('setValue', '');
                    return f.length;
                }
            }
            return 0;
        }

        function _clearCombo(name) {
            var cc = ['combobox', 'combotree', 'combogrid', 'datetimebox', 'datebox', 'combo'];
            var c = $(jq).find('[comboName="' + name + '"]');
            if (c.length && !c.attr('noclear')) {
                for (var i = 0; i < cc.length; i++) {
                    var type = cc[i];
                    if (c.hasClass(type + '-f')) {
                        c[type]('clear');
                        return;
                    }
                }
            }
        }
    },
    invalid: function (jq, result) {
        var str = '';
        for (var i = 0; i < result.data.length; i++) {
            var name = result.data[i].Key;
            var msg = result.data[i].Value;
            var count = _invalidOther(name, msg);
            if (count == 0 && !_invalidCombo(name, msg)) {
                str += result.data[i].Value;
            }
        }

        if (str != '') {
            common.alert(str);
        }

        function _invalidOther(name, msg) {
            var count = 0;
            var pp = ['textbox', 'numberbox', 'slider'];
            for (var i = 0; i < pp.length; i++) {
                var p = pp[i];
                var f = $(jq).find('input[' + p + 'Name="' + name + '"]');
                if (f.length) {
                    f[p]('setInvalid', msg);
                    count += f.length;
                }
            }
            return count;
        }

        function _invalidCombo(name, msg) {
            var form = $(jq);
            var cc = ['combobox', 'combotree', 'combogrid', 'datetimebox', 'datebox', 'combo'];
            var c = form.find('[comboName="' + name + '"]');
            if (c.length) {
                for (var i = 0; i < cc.length; i++) {
                    var type = cc[i];
                    if (c.hasClass(type + '-f')) {
                        c[type]('setInvalid', msg);
                        return true;
                    }
                }
            }
            return false;
        }
    }
});

$.extend($.fn.validatebox.defaults.rules, {
    minLength: { // 判断最小长度
        validator: function (value, param) {
            return value.length >= param[0];
        },
        message: '最少输入 {0} 个字符。'
    },
    length: {
        validator: function (value, param) {
            var len = $.trim(value).length;
            return len >= param[0] && len <= param[1];
        },
        message: "内容长度介于{0}和{1}之间."
    },
    phone: {// 验证电话号码
        validator: function (value) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '电话号码格式不正确'
    },
    mobile: {// 验证手机号码
        validator: function (value) {
            return /^(13|15|18|17)\d{9}$/i.test(value);
        },
        message: '手机号码格式不正确'
    },
    phoneOrMobile: {//验证手机或电话
        validator: function (value) {
            return /^(13|15|18)\d{9}$/i.test(value) || /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '请填入手机或电话号码'
    },
    idcard: {// 验证身份证
        validator: function (value) {
            return /^\d{15}(\d{2}[A-Za-z0-9])?$/i.test(value);
        },
        message: '身份证号码格式不正确'
    },
    floatOrInt: {// 验证是否为小数或整数
        validator: function (value) {
            return /^(\d{1,3}(,\d\d\d)*(\.\d{1,3}(,\d\d\d)*)?|\d+(\.\d+))?$/i.test(value);
        },
        message: '请输入数字，并保证格式正确'
    },
    currency: {// 验证货币
        validator: function (value) {
            return /^d{0,}(\.\d+)?$/i.test(value);
        },
        message: '货币格式不正确'
    },
    integer: {// 验证整数
        validator: function (value) {
            return /^[+]?[1-9]+\d*$/i.test(value);
        },
        message: '请输入整数'
    },
    chinese: {// 验证中文
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/i.test(value);
        },
        message: '请输入中文'
    },
    english: {// 验证英语
        validator: function (value) {
            return /^[A-Za-z]+$/i.test(value);
        },
        message: '请输入英文'
    },
    unnormal: {// 验证是否包含空格和非法字符
        validator: function (value) {
            return /.+/i.test(value);
        },
        message: '输入值不能为空和包含其他非法字符'
    },
    username: {// 验证用户名
        validator: function (value) {
            return /^[a-zA-Z][a-zA-Z0-9_]{1,15}$/i.test(value);
        },
        message: '字母开头，包含字母数字下划线'
    },
    zip: {// 验证邮政编码
        validator: function (value) {
            return /^[1-9]\d{5}$/i.test(value);
        },
        message: '邮政编码格式不正确'
    },
    ip: {// 验证IP地址
        validator: function (value) {
            return /d+.d+.d+.d+/i.test(value);
        },
        message: 'IP地址格式不正确'
    },
    name: {// 验证姓名，可以是中文或英文
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/i.test(value) | /^\w+[\w\s]+\w+$/i.test(value);
        },
        message: '请输入姓名'
    },
    email: {
        validator: function (value) {
            return /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(value);
        },
        message: '电子邮件格式不正确'
    },
    same: {
        validator: function (value, param) {
            if ($("#" + param[0]).val() != "" && value != "") {
                return $("#" + param[0]).val() == value;
            } else {
                return true;
            }
        },
        message: '两次输入的密码不一致！'
    },
    remote: {
        validator: function (value, param) {
            if (typeof param[0] == "function") {
                return param[0](value);
            }
            else {
                var _data = {};
                _data[param[1]] = value;
                var rslt = $.ajax({ url: param[0], dataType: "json", data: _data, async: false, cache: false, type: "post" }).responseText;
                return rslt == "true";
            }
        }, message: "请修正该字段。"
    }
});

$.extend($.fn.validatebox.methods, {
    setInvalid: function (jq, msg) {
        jq.addClass('validatebox-invalid');
        var data = jq.data("validatebox");
        data.message = msg;
        var opts = data.options;
        jq.tooltip($.extend({}, opts.tipOptions, { content: data.message, position: opts.tipPosition, deltaX: opts.deltaX })).tooltip("show");
        data.tip = true;
    }
});

$.extend($.fn.datagrid.defaults, {
    striped: true
});

$.extend($.fn.treegrid.defaults, {
    striped: true
});

$.extend($.fn.tabs.methods, {
    iframe: function (jq, opts) {
        var tab = jq.tabs('getTab', opts.index);
        opts = $.extend({ index: 0, url: '' }, opts);
        if (tab && tab.children().length == 0) {
            var content = '<iframe style="width:100%;height:100%;" frameborder="false" src="' + opts.url + '"></iframe>';
            jq.tabs('update', {
                tab: tab,
                options: { content: content }
            });
        }
    }
});