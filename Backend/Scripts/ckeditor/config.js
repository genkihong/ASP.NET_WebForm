/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = '/Backend/Scripts/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Backend/Scripts/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Backend/Scripts/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Backend/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Backend/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Backend/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
