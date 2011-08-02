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
function GetCategory(cgParentID,targetSel) {
    $.ajax({
        url: "/CgJson/" + cgParentID,
        type: 'post',
        success: function (data) {
            _createOption(data, targetSel);
        },
        error: function () {
        }
    });
}

function _createOption(data, targetSel) {
    if ($(data).length > 0) {
        if ($('#' + targetSel).length < 1) {//

            var parSelID = targetSel;

            if (targetSel.lastIndexOf('_') > 0) {
                parSelID = targetSel.substring(0, targetSel.lastIndexOf('_'));
            }
            //alert(parSelID);
            //alert($('#' + parSelID).parent());
            $('#' + parSelID).parent().append('<select id="' + targetSel + '">请选择</select>');
        }
        $('#' + targetSel).append('<option value="-1">请选择</option>');
        $(data).each(function (i, d) {
            $('#' + targetSel).append('<option value="' + d.cid + '">' + d.cname + '</option>');
            //$().append().empty();
        });
        _selOnChange(targetSel);
        $('#' + targetSel).change();
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
        $('#hidcategory').val($(this).val());
        GetCategory($(this).val(), subSelID);
    });
}