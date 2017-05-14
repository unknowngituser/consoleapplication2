/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	config.language = 'ru';
    // config.uiColor = '#AADC6E';
    config.toolbar = [
	//{ name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'] },
	{ name: 'clipboard', items: ['Undo', 'Redo', '-', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'] },
    { name: 'insert', items: ['Image', 'VideoEmbed', 'Youtube', '-', 'Table', 'Smiley', 'SpecialChar'] },
	//{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'] },
	//{ name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
'/',
	{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', '-', 'RemoveFormat'] },
	{ name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
	{ name: 'links', items: ['Link', 'Unlink'] },
'/',
	{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
	{ name: 'colors', items: ['TextColor', 'BGColor'] },
	{ name: 'tools', items: ['Maximize'] }
    ];
    config.resize_enabled = false;
    config.extraPlugins = 'videoembed,youtube,autogrow';
    config.autoGrow_onStartup = true;

    config.font_names =
    'Akrobat/Akrobat-Regular,Akrobat;' +
    'Akrobat Light/Akrobat-Light,sans-serif;' +
    'Arial/Arial, Helvetica, sans-serif;' +
    'Comic Sans MS/comic sans ms,sans-serif;'+
    'Courier New/courier new,courier,monospace;'+
    'Georgia/georgia,palatino,serif;'+
    'Helvetica/helvetica,arial,sans-serif;' +
    'Lobster/Lobster,Lobster-Regular;'
    'Tahoma/tahoma,arial,helvetica,sans-serif;'+
    'Times New Roman/times new roman,times,serif;'+
    'Verdana/verdana,geneva,sans-serif;';
    

    config.removePlugins = 'iframe';
    config.filebrowserUploadUrl = "http://"+window.location.hostname + ':' + window.location.port + "/Admin/News/UploadImage";
};
