// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const upload_btn = document.getElementById('upload_photo_btn');
const upload_photo_form = document.getElementById('upload_photo_form');
const customFile = document.getElementById('customFile');


if (upload_btn != null) {
    upload_btn.addEventListener('click', event => {
        customFile.click();
    });
}
if (customFile != null) {
    customFile.addEventListener('change', event => {

        let reader = new FileReader();
        reader.onload = function () {
            document.getElementById('avatar').src = this.result;
        }
        reader.readAsDataURL(event.target.files[0]);
        let formData = new FormData(upload_photo_form);
        formData.append("UploadPhoto.File", event.target.files[0]);
    });
}


(function () {
    'use strict';
    var $ = jQuery;
    $.fn.extend({
        filterTable: function () {
            return this.each(function () {
                $(this).on('keyup', function (e) {
                    $('.filterTable_no_results').remove();
                    var $this = $(this),
                        search = $this.val().toLowerCase(),
                        target = $this.attr('data-filters'),
                        $target = $(target),
                        $rows = $target.find('tbody tr');

                    if (search == '') {
                        $rows.show();
                    } else {
                        $rows.each(function () {
                            var $this = $(this);
                            $this.text().toLowerCase().indexOf(search) === -1 ? $this.hide() : $this.show();
                        })
                        if ($target.find('tbody tr:visible').size() === 0) {
                            var col_count = $target.find('tr').first().find('td').size();
                            var no_results = $('<tr class="filterTable_no_results"><td colspan="' + col_count + '">No results found</td></tr>')
                            $target.find('tbody').append(no_results);
                        }
                    }
                });
            });
        }
    });
    $('[data-action="filter"]').filterTable();
})(jQuery);

$(function () {
    // attach table filter plugin to inputs
    $('[data-action="filter"]').filterTable();

    $('.container').on('click', '.panel-heading span.filter', function (e) {
        var $this = $(this),
            $panel = $this.parents('.panel');

        $panel.find('.panel-body').slideToggle();
        if ($this.css('display') != 'none') {
            $panel.find('.panel-body input').focus();
        }
    });
    $('[data-toggle="tooltip"]').tooltip();
})