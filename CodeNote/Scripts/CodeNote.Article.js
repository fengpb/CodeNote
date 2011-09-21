var Article = {
    AddUrl: '/Article/DoAdd'
};
function AddArticle() {
    var subject = $('#articlesubject').val();
    var body = $('#articlebody').val();
    $.ajax({
        url: Article.AddUrl,
        type: 'post',
        dataType: 'json',
        data: { subject: subject, body: body },
        success: function (data) {
            alert(data.Message);
        },
        error: function () {
        }
    });
};
function GetCategory(cgParentID, targetSel, callBack) {
    $.ajax({
        url: "/CgJson/" + cgParentID,
        type: 'post',
        success: function (data) {
            _createOption(data, targetSel);
            if (callBack) {
                callBack(targetSel);
            }
        },
        error: function () {
        }
    });
}

function _createOption(data, targetSel) {
    if ($(data).length > 0) {

        var parSelID = targetSel;

        if (targetSel.lastIndexOf('_') > 0) {
            parSelID = targetSel.substring(0, targetSel.lastIndexOf('_'));
            $('#' + targetSel).remove();
            $('#' + parSelID).parent().append('<select id="' + targetSel + '"></select>');
        }

        $('#' + targetSel).append('<option value="">请选择</option>');
        $(data).each(function (i, d) {
            $('#' + targetSel).append('<option value="' + d.cid + '">' + d.cname + '</option>');
            //$().append().empty();
        });
        _selOnChange(targetSel);
    } else {
        _delCgSel(targetSel);
    }
}
function _delCgSel(targetSel) {
    var subSelID = targetSel + "_sub";
    $('#' + subSelID).remove();
    $('#' + targetSel).remove();
}
function _selOnChange(targetSel) {
    $('#' + targetSel).change(function () {
        //alert();
        var subSelID = targetSel + "_sub";

        GetCategory($(this).val(), subSelID);

        $('#hidcategory').val($(this).val());
    });
}

function SelDefaultValue(target) {
    var value = $('#hidcategory').val();
    //alert(value);
    $('#' + target + ' option').each(function (i, v) {
        if (value.indexOf($(this).val()) != -1) {
            $(this).attr('selected', 'selected');
            GetCategory($(this).val(), target + '_sub', SelDefaultValue);
        }
    });
}