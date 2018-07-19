var ccVM = {
    AddNewReasonToGetThisCard: function () {
        var rowCount = Number($('#tblTopReasonsToGetThisCreditCard tr').length) + 1;
        var row = "<tr>";
        row += '        <td> <label style="width:80px" class="form-control">' + rowCount + '</td >';
        row += "        <td><input class='form-control text-box single-line' name='ReasonsToGetThisCard' type='text' value=''></td>"
        row += "        <td><label class='fa fa-close btn btn-danger' onclick='ccVM.RemoveReasionToGetThisCard(this)'></label></td>";
        row += "   </tr>";
        $("#tblTopReasonsToGetThisCreditCard").append(row);
    },

    RemovePoint: function (obj) {
        html = $(obj).parent().parent().parent();
        var count = 1;
        $(html).find("tr td:first-child").each(function (i, l) {
            if ($(obj).parent().parent().find("td:first-child").find("label").text() != $(l).find("label").text()) {
                $(l).find("label").text(count++);
            }
        });
        $(obj).parent().parent().remove();
    }
}

var html;