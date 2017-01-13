/**
 * The Patch for jQuery EasyUI 1.4
 */
(function($){
	var plugin = $.fn._size;
	$.fn._size = function(options, parent){
		if (typeof options != 'string'){
			return this.each(function(){
				parent = parent || $(this).parent();
				if (parent.length){
					plugin.call($(this), options, parent);
				}
			});
		} else if (options == 'unfit'){
			return this.each(function(){
				var p = $(this).parent();
				if (p.length){
					plugin.call($(this), options, parent);
				}
			});
		} else {
			return plugin.call(this, options, parent);
		}
	}
})(jQuery);

(function($){
	$.map(['validatebox','textbox','filebox','searchbox',
			'combo','combobox','combogrid','combotree',
			'datebox','datetimebox','numberbox',
			'spinner','numberspinner','timespinner','datetimespinner'], function(plugin){
		if ($.fn[plugin]){
			if ($.fn[plugin].defaults.events){
				$.fn[plugin].defaults.events.click = function(e){
					if (!$(e.data.target).is(':focus')){
						$(e.data.target).trigger('focus');
					}
				};
			}
		}
	});
	$.fn.combogrid.defaults.height = 22;
	$(function(){
		$(document).bind('mousewheel', function(e){
			$(e.target).trigger('mousedown.combo');
		});
	});
})(jQuery);

(function($){
	function setMe(target){
		var state = $.data(target, 'textbox');
		var opts = state.options;
		state.textbox.find('.textbox-addon .textbox-icon').each(function(index){
			$(this).attr('tabindex', '-1');
		});
		$(target).textbox('textbox').unbind('focus.textbox').bind('focus.textbox', function(e){
			var tb = $(target).next();
			if (tb.hasClass('textbox-focused')){return;}
			if ($(this).val() != opts.value){
				$(this).val(opts.value);
			}
			$(this).removeClass('textbox-prompt');
			tb.addClass('textbox-focused');
		});
	}

	var plugin = $.fn.textbox;
	$.fn.textbox = function(options, param){
		if (typeof options != 'string'){
			return this.each(function(){
				plugin.call($(this), options, param);
				setMe(this);
			});
		} else {
			return plugin.call(this, options, param);
		}
	};
	$.fn.textbox.methods = plugin.methods;
	$.fn.textbox.defaults = plugin.defaults;
	$.fn.textbox.parseOptions = plugin.parseOptions;
})(jQuery);

(function($){
	function setMe(target){
		var addon = $(target).next().find('.textbox-addon');
		addon.find('.spinner-arrow-up,.spinner-arrow-down').attr('tabindex','-1');
	}

	var plugin = $.fn.spinner;
	$.fn.spinner = function(options, param){
		if (typeof options != 'string'){
			return this.each(function(){
				plugin.call($(this), options, param);
				setMe(this);
			});
		} else {
			return plugin.call(this, options, param);
		}
	};
	$.fn.spinner.methods = plugin.methods;
	$.fn.spinner.defaults = plugin.defaults;
	$.fn.spinner.parseOptions = plugin.parseOptions;
})(jQuery);

(function($){
	$.extend($.fn.form.methods, {
		clear: function(jq){
			return jq.each(function(){
				var target = this;
				$('input,select,textarea', target).each(function(){
					var t = this.type, tag = this.tagName.toLowerCase();
					if (t == 'text' || t == 'hidden' || t == 'password' || tag == 'textarea'){
						this.value = '';
					} else if (t == 'file'){
						var file = $(this);
						if (!file.hasClass('textbox-value')){
							var newfile = file.clone().val('');
							newfile.insertAfter(file);
							if (file.data('validatebox')){
								file.validatebox('destroy');
								newfile.validatebox();
							} else {
								file.remove();
							}
						}
					} else if (t == 'checkbox' || t == 'radio'){
						this.checked = false;
					} else if (tag == 'select'){
						this.selectedIndex = -1;
					}
				});
				
				var t = $(target);
				var plugins = ['textbox','combo','combobox','combotree','combogrid','slider'];
				for(var i=0; i<plugins.length; i++){
					var plugin = plugins[i];
					var r = t.find('.'+plugin+'-f');
					if (r.length && r[plugin]){
						r[plugin]('clear');
					}
				}
				$(target).form('validate');
			});
		}
	});
	$.extend($.fn.form.defaults, {
		onSubmit:function(){
			$(this).find('.textbox-text:focus').blur();
			return $(this).form('validate');
		}
	});
})(jQuery);

(function($){
	function setSize(target, param){
		var opts = $.data(target, 'linkbutton').options;
		if (param){
			$.extend(opts, param);
		}
		if (opts.width || opts.height || opts.fit){
			var btn = $(target);
			var parent = btn.parent();
			var isVisible = btn.is(':visible');
			if (!isVisible){
				var spacer = $('<div style="display:none"></div>').insertBefore(target);
				var style = {
					position: btn.css('position'),
					display: btn.css('display'),
					left: btn.css('left')
				};
				btn.appendTo('body');
				btn.css({
					position:'absolute',
					display:'inline-block',
					left:-20000
				});
			}
			btn._size(opts, parent);
			var left = btn.find('.l-btn-left');
			left.css('margin-top', 0);
			left.css('margin-top', parseInt((btn.height()-left.height())/2)+'px');
			if (!isVisible){
				btn.insertAfter(spacer);
				btn.css(style);
				spacer.remove();
			}
		}
	}

	var plugin = $.fn.linkbutton;
	$.fn.linkbutton = function(options, param){
		if (typeof options != 'string'){
			return this.each(function(){
				plugin.call($(this), options, param);
				setSize(this);
			});
		} else {
			return plugin.call(this, options, param);
		}
	};
	$.fn.linkbutton.methods = plugin.methods;
	$.fn.linkbutton.defaults = plugin.defaults;
	$.fn.linkbutton.parseOptions = plugin.parseOptions;
	$.extend($.fn.linkbutton.methods, {
		resize: function(jq, param){
			return jq.each(function(){
				setSize(this, param);
			})
		}
	})
})(jQuery);

(function($){
	var plugin = $.fn.dialog;
	$.fn.dialog = function(options, param){
		var result = plugin.call(this, options, param);
		if (typeof options != 'string'){
			this.each(function(){
				var opts = $(this).panel('options');
				if (isNaN(parseInt(opts.height))){
					$(this).css('height', '');
				}
				var onResize = opts.onResize;
				opts.onResize = function(w, h){
					onResize.call(this, w, h);
					if (isNaN(parseInt(opts.height))){
						$(this).css('height', '');
					}
					var shadow = $.data(this, 'window').shadow;
					if (shadow){
						var cc = $(this).panel('panel');
						shadow.css({
							width: cc._outerWidth(),
							height: cc._outerHeight()
						});
					}
				}
				if (opts.closed){
					var pp = $(this).panel('panel');
					pp.show();
					$(this).panel('resize');
					pp.hide();
				}
			});
		}
		return result;
	};
	$.fn.dialog.methods = plugin.methods;
	$.fn.dialog.parseOptions = plugin.parseOptions;
	$.fn.dialog.defaults = plugin.defaults;
})(jQuery);

(function($){
	function createTab(container, pp, options) {
		var state = $.data(container, 'tabs');
		options = options || {};
		
		// create panel
		pp.panel({
			border: false,
			noheader: true,
			closed: true,
			doSize: false,
			iconCls: (options.icon ? options.icon : undefined)
		});
		
		var opts = pp.panel('options');
		$.extend(opts, options, {
			onLoad: function(){
				if (options.onLoad){
					options.onLoad.call(this, arguments);
				}
				state.options.onLoad.call(container, $(this));
			}
		});
		
		var tabs = $(container).children('div.tabs-header').find('ul.tabs');
		
		opts.tab = $('<li></li>').appendTo(tabs);	// set the tab object in panel options
		opts.tab.append(
				'<a href="javascript:void(0)" class="tabs-inner">' +
				'<span class="tabs-title"></span>' +
				'<span class="tabs-icon"></span>' +
				'</a>'
		);
		
		$(container).tabs('update', {
			tab: pp,
			options: opts
		});
	}
	function addTab(container, options) {
		var opts = $.data(container, 'tabs').options;
		var tabs = $.data(container, 'tabs').tabs;
		if (options.selected == undefined) options.selected = true;
		
		var pp = $('<div></div>').appendTo($(container).children('div.tabs-panels'));
		tabs.push(pp);
		createTab(container, pp, options);
		
		opts.onAdd.call(container, options.title, tabs.length-1);
		
		$(container).tabs('resize');
		if (options.selected){
			$(container).tabs('select', tabs.length-1);
		}
	}
	$.extend($.fn.tabs.methods, {
		add: function(jq, options){
			return jq.each(function(){
				addTab(this, options);
			})
		}
	})
})(jQuery);

(function($){
	$.extend($.fn.menubutton.methods, {
		enable: function(jq){
			return jq.each(function(){
				$(this).data('menubutton').options.disabled = false;
				$(this).linkbutton('enable');
			});
		}
	});
})(jQuery);

(function($){
    var onAfterRender = $.fn.datagrid.defaults.view.onAfterRender;
    $.extend($.fn.datagrid.defaults.view, {
		updateRow: function(target, rowIndex, row){
			var opts = $.data(target, 'datagrid').options;
			var rows = $(target).datagrid('getRows');
			
			var oldStyle = _getRowStyle(rowIndex);
			$.extend(rows[rowIndex], row);
			var newStyle = _getRowStyle(rowIndex);
			var oldClassValue = oldStyle.c;
			var styleValue = newStyle.s;
			var classValue = 'datagrid-row ' + (rowIndex % 2 && opts.striped ? 'datagrid-row-alt ' : ' ') + newStyle.c;
			
			function _getRowStyle(rowIndex){
				var css = opts.rowStyler ? opts.rowStyler.call(target, rowIndex, rows[rowIndex]) : '';
				var classValue = '';
				var styleValue = '';
				if (typeof css == 'string'){
					styleValue = css;
				} else if (css){
					classValue = css['class'] || '';
					styleValue = css['style'] || '';
				}
				return {c:classValue, s:styleValue};
			}
			function _update(frozen){
				var fields = $(target).datagrid('getColumnFields', frozen);
				var tr = opts.finder.getTr(target, rowIndex, 'body', (frozen?1:2));
				var checked = tr.find('div.datagrid-cell-check input[type=checkbox]').is(':checked');
				tr.html(this.renderRow.call(this, target, fields, frozen, rowIndex, rows[rowIndex]));
				tr.attr('style', styleValue).removeClass(oldClassValue).addClass(classValue);
				if (checked){
					tr.find('div.datagrid-cell-check input[type=checkbox]')._propAttr('checked', true);
				}
			}
			
			_update.call(this, true);
			_update.call(this, false);
			$(target).datagrid('fixRowHeight', rowIndex);
		},
    	onAfterRender: function(target){
    		onAfterRender.call($.fn.datagrid.defaults.view, target);
    		setTimeout(function(){
    			var opts = $(target).datagrid('options');
    			opts.pageNumber = opts.pageNumber || 1;
    		},0);
    	}
    });
    
	$.fn.datagrid.defaults.loader = function(param, success, error){
		var opts = $(this).datagrid('options');
		if (!opts.url) return false;
		if (opts.pagination && opts.pageNumber == 0){
			opts.pageNumber = 1;
			param.page = 1;
		}
		if (param.page == 0){
			return false;
		}
		$.ajax({
			type: opts.method,
			url: opts.url,
			data: param,
			dataType: 'json',
			success: function(data){
				success(data);
			},
			error: function(){
				error.apply(this, arguments);
			}
		});
	};
})(jQuery);
(function($){
	function indexOfArray(a,o){
		for(var i=0,len=a.length; i<len; i++){
			if (a[i] == o) return i;
		}
		return -1;
	}
	function endEdit(target, index){
		var state = $.data(target, 'datagrid');
		var opts = state.options;
		var updatedRows = state.updatedRows;
		var insertedRows = state.insertedRows;
		
		var tr = opts.finder.getTr(target, index);
		var row = opts.finder.getRow(target, index);
		if (!tr.hasClass('datagrid-row-editing')) {
			return;
		}
		
		if (!$(target).datagrid('validateRow', index)){return}
		
		var changed = false;
		var changes = {};
		tr.find('div.datagrid-editable').each(function(){
			var field = $(this).parent().attr('field');
			var ed = $.data(this, 'datagrid.editor');
			var t = $(ed.target);
			var input = t.data('textbox') ? t.textbox('textbox') : t;
			input.triggerHandler('blur');
			var value = ed.actions.getValue(ed.target);
			if (row[field] != value){
				row[field] = value;
				changed = true;
				changes[field] = value;
			}
		});
		if (changed){
			if (indexOfArray(insertedRows, row) == -1){
				if (indexOfArray(updatedRows, row) == -1){
					updatedRows.push(row);
				}
			}
		}
		opts.onEndEdit.call(target, index, row, changes);
		
		tr.removeClass('datagrid-row-editing');
		
		destroyEditor(target, index);
		$(target).datagrid('refreshRow', index);
		
		opts.onAfterEdit.call(target, index, row, changes);
	}
	function destroyEditor(target, index){
		var opts = $.data(target, 'datagrid').options;
		var tr = opts.finder.getTr(target, index);
		tr.children('td').each(function(){
			var cell = $(this).find('div.datagrid-editable');
			if (cell.length){
				var ed = $.data(cell[0], 'datagrid.editor');
				if (ed.actions.destroy) {
					ed.actions.destroy(ed.target);
				}
				cell.html(ed.oldHtml);
				$.removeData(cell[0], 'datagrid.editor');
				
				cell.removeClass('datagrid-editable');
				cell.css('width','');
			}
		});
	}
	
	$.extend($.fn.datagrid.methods, {
		endEdit: function(jq, index){
			return jq.each(function(){
				endEdit(this, index);
			})
		}
	})
})(jQuery);

(function($){
	function setGrid(target){
		var opts = $.data(target, 'propertygrid').options;
		$(target).datagrid('options').onBeforeEdit = function(index, row){
			if (opts.onBeforeEdit.call(target, index, row) == false){return false;}
			var dg = $(this);
			var col = dg.datagrid('getColumnOption', 'value');
			col.editor = row.editor;			
		}
	}

	var plugin = $.fn.propertygrid;
	$.fn.propertygrid = function(options, param){
		if (typeof options == 'string'){
			return plugin.call(this, options, param);
		} else {
			return this.each(function(){
				plugin.call($(this), options, param);
				setGrid(this);
			});
		}
	};
	$.fn.propertygrid.defaults = plugin.defaults;
	$.fn.propertygrid.methods = plugin.methods;
	$.fn.propertygrid.parseOptions = plugin.parseOptions;
})(jQuery);

(function($){
	$.fn.numberbox.defaults.filter = function(e){
		var opts = $(this).numberbox('options');
		var s = $(this).numberbox('getText');
		if (e.which == 45){	//-
			return (s.indexOf('-') == -1 ? true : false);
		}
		var c = String.fromCharCode(e.which);
		if (c == opts.decimalSeparator){
			return (s.indexOf(c) == -1 ? true : false);
		} else if (c == opts.groupSeparator){
			return true;
		} else if ((e.which >= 48 && e.which <= 57 && e.ctrlKey == false && e.shiftKey == false) || e.which == 0 || e.which == 8) {
			return true;
		} else if (e.ctrlKey == true && (e.which == 99 || e.which == 118)) {
			return true;
		} else {
			return false;
		}
	}
})(jQuery);

(function($){
	var FILE_INDEX = 0;
	function buildFileBox(target){
		var state = $.data(target, 'filebox');
		var opts = state.options;
		var id = 'filebox_file_id_' + (++FILE_INDEX);
		$(target).addClass('filebox-f').textbox($.extend({}, opts, {
			buttonText: opts.buttonText ? ('<label for="' + id + '">' + opts.buttonText + '</label>') : ''
		}));
		$(target).textbox('textbox').attr('readonly','readonly');
		state.filebox = $(target).next().addClass('filebox');
		state.filebox.find('.textbox-value').remove();
		opts.oldValue = "";
		var file = $('<input type="file" class="textbox-value">').appendTo(state.filebox);
		file.attr('id', id).attr('name', $(target).attr('textboxName')||'');
		file.css('visibility', 'visible');
		file.change(function(){
			$(target).filebox('setText', this.value);
			opts.onChange.call(target, this.value, opts.oldValue);
			opts.oldValue = this.value;
		});
		var btn = $(target).filebox('button');
		if (btn.length){
			if (btn.linkbutton('options').disabled){
				file.attr('disabled', 'disabled');
			} else {
				file.removeAttr('disabled');
			}			
		}
	}

	var plugin = $.fn.filebox;
	$.fn.filebox = function(options, param){
		if (typeof options != 'string'){
			return this.each(function(){
				plugin.call($(this), options, param);
				buildFileBox(this);
			});
		} else {
			return plugin.call(this, options, param);
		}
	};
	$.fn.filebox.methods = plugin.methods;
	$.fn.filebox.defaults = plugin.defaults;
	$.fn.filebox.parseOptions = plugin.parseOptions;
})(jQuery);

(function($){
	function forNodes(data, callback){
		var nodes = [];
		for(var i=0; i<data.length; i++){
			nodes.push(data[i]);
		}
		while(nodes.length){
			var node = nodes.shift();
			if (callback(node) == false){return;}
			if (node.children){
				for(var i=node.children.length-1; i>=0; i--){
					nodes.unshift(node.children[i]);
				}
			}
		}
	}
	function findNodeBy(target, param, value){
		var data = $.data(target, 'tree').data;
		var result = null;
		forNodes(data, function(node){
			if (node[param] == value){
				result = attachProperties(node);
				return false;
			}
		});
		return result;
	}
	function getNode(target, nodeEl){
		return findNodeBy(target, 'domId', $(nodeEl).attr('id'));
	}
	function attachProperties(node){
		var d = $('#'+node.domId);
		node.target = d[0];
		node.checked = d.find('.tree-checkbox').hasClass('tree-checkbox1');
		return node;
	}
	$.fn.tree.methods.getChildren = function(jq, nodeEl){
		var target = jq[0];
		var nodes = [];
		var n = getNode(target, nodeEl);
		var data = n ? (n.children||[]) : $.data(target, 'tree').data;
		forNodes(data, function(node){
			nodes.push(attachProperties(node));
		});
		return nodes;
	}
})(jQuery);

