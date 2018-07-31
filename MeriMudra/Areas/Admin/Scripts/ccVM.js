var ccVM = {
    AddNewReasonToGetThisCard: function () {
        var rowCount = Number($('#tblTopReasonsToGetThisCreditCard tr').length) + 1;
        var row = "<tr>";
        row += '        <td> <label style="width:80px" class="form-control">' + rowCount + '</td >';
        row += "        <td><input class='form-control text-box single-line' name='ReasonsToGetThisCard' type='text' value=''></td>"
        row += "        <td><label class='fa fa-minus-circle btn btn-danger' onclick='ccVM.RemovePoint(this)'></label></td>";
        row += "   </tr>";
        $("#tblTopReasonsToGetThisCreditCard").append(row);
    },
    AddBenefitsAndFeatures: function () {
        var headingCount = Number($('#maxHeadingId').val()) + 1;
        $('#maxHeadingId').val(headingCount);
        var tbl = ' <table width="100%" class="table table-hover Heading">';
        tbl += '       <thead class="thead-light">';
        tbl += '   					<tr>';
        tbl += '   						<th width="10%"> Heading </th>';
        tbl += '   						<th width="80%"><input class="form-control text-box single-line" id="Headding' + headingCount + '" name="Headding' + headingCount + '" type="text" value=""></th>';
        tbl += '   						<th width="10%">';
        tbl += '   							<label class="fa fa-trash btn btn-danger" onclick="ccVM.RemoveHeading(this)">  </label>';
        tbl += '   							<label class="fa fa-plus btn btn-success" onclick="ccVM.AddPointToBenefitsAndFeatures(this)"></label>';
        tbl += '   						</th>';
        tbl += '   					</tr>';
        tbl += '   				</thead>';
        tbl += '   				<tbody>';
        tbl += '                <tr>';
        tbl += '                    <td><label style="width:80px" class="form-control"> 1 </label></td>';
        tbl += '                    <td><input class="form-control text-box single-line" name="Heading' + (headingCount) + 'Point1" type="text" value=""></td>';
        tbl += '                    <td><label class="fa fa-minus-circle btn btn-danger" onclick="ccVM.RemovePoint(this)"> </label></td>';
        tbl += '                </tr>';
        tbl += ' 				</tbody>';
        tbl += ' 		    </table>';
        $("#BenefitsAndFeaturesSection").append(tbl);
    },
    AddPointToBenefitsAndFeatures: function (obj) {
        var rowCount = Number($(obj).parent().parent().parent().parent().find('tbody tr').length) + 1;
        var row = ' <tr>';
        row += '        <td><label style="width:80px" class="form-control">' + rowCount + '</label></td>';
        row += '        <td><input class="form-control text-box single-line" name="Heading' + $('#maxHeadingId').val() + 'Point' + rowCount + '" type="text" value=""></td>';
        row += '        <td><label class="fa fa-minus-circle btn btn-danger" onclick="ccVM.RemovePoint(this)"> </label></td>';
        row += '    </tr>';
        $(obj).parent().parent().parent().parent().find('tbody').append(row);
    },
    AddFeesAndCharges: function () {
        var headingCount = Number($('#maxHeadingId').val()) + 1;
        $('#maxHeadingId').val(headingCount);
        var tbl = ' <table width="100%" class="table table-hover Heading">';
        tbl += '       <thead class="thead-light">';
        tbl += '   					<tr>';
        tbl += '   						<th width="10%"> Heading   </th>';
        tbl += '   						<th width="80%"><input class="form-control text-box single-line" id="Headding' + headingCount + '" name="Headding' + headingCount + '" type="text" value=""></th>';
        tbl += '   						<th width="10%">';
        tbl += '   							<label class="fa fa-trash btn btn-danger" onclick="ccVM.RemoveHeading(this)">  </label>';
        tbl += '   							<label class="fa fa-plus btn btn-success" onclick="ccVM.AddPointToBenefitsAndFeatures(this)"></label>';
        tbl += '   						</th>';
        tbl += '   					</tr>';
        tbl += '   				</thead>';
        tbl += '   				<tbody>';
        tbl += '                <tr>';
        tbl += '                    <td><label style="width:80px" class="form-control"> 1 </label></td>';
        tbl += '                    <td><input class="form-control text-box single-line" name="Heading' + (headingCount) + 'Point1" type="text" value=""></td>';
        tbl += '                    <td><label class="fa fa-minus-circle btn btn-danger" onclick="ccVM.RemovePoint(this)"> </label></td>';
        tbl += '                </tr>';
        tbl += ' 				</tbody>';
        tbl += ' 		    </table>';
        $("#FeesAndChargesSection").append(tbl);
    },
    AddPointToFeesAndCharges: function (obj) {
        var rowCount = Number($(obj).parent().parent().parent().parent().find('tbody tr').length) + 1;
        var row = '<tr>';
        row += '    <td><label style="width:80px" class="form-control"> ' + rowCount + '</label></td>';
        row += '    <td width="20%"> <input placeholder="key" class="form-control text-box single-line" name="feesAndChargeKey' + rowCount + '" type="text" value=""></td>';
        row += '    <td> <input placeholder="description" class="form-control text-box single-line" name="feesAndChargeValue' + rowCount + '" type="text" value=""></td>';
        row += '    <td> <label class="fa fa-minus-circle btn btn-danger" onclick="ccVM.RemovePoint(this)"> </label> </td>';
        row += '   </tr>';
        $(obj).parent().parent().parent().parent().find('tbody').append(row);

    },
    RemoveHeading: function (obj) {
        $(obj).parent().parent().parent().parent().remove();
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
    },

    //---------------------------------------------------------

    AddRedeemReward: function () {
        var headingCount = Number($('#maxHeadingId').val()) + 1;
        $('#maxHeadingId').val(headingCount);
        var tbl = ' <table width="100%" class="table table-hover Heading">';
        tbl += '       <thead class="thead-light">';
        tbl += '   					<tr>';
        tbl += '   						<th width="10%"> Heading </th>';
        tbl += '   						<th width="80%"><input class="form-control text-box single-line" id="Headding' + headingCount + '" name="Headding' + headingCount + '" type="text" value=""></th>';
        tbl += '   						<th width="10%">';
        tbl += '   							<label class="fa fa-trash btn btn-danger" onclick="ccVM.RemoveHeading(this)">  </label>';
        tbl += '   							<label class="fa fa-plus btn btn-success" onclick="ccVM.AddPointToBenefitsAndFeatures(this)"></label>';
        tbl += '   						</th>';
        tbl += '   					</tr>';
        tbl += '   				</thead>';
        tbl += '   				<tbody>';
        tbl += '                <tr>';
        tbl += '                    <td><label style="width:80px" class="form-control"> 1 </label></td>';
        tbl += '                    <td><input class="form-control text-box single-line" name="Heading' + (headingCount) + 'Point1" type="text" value=""></td>';
        tbl += '                    <td><label class="fa fa-minus-circle btn btn-danger" onclick="ccVM.RemovePoint(this)"> </label></td>';
        tbl += '                </tr>';
        tbl += ' 				</tbody>';
        tbl += ' 		    </table>'; $("#RedeemRewardSection").append(tbl);
    },

    GetNewHeadingId: function (section) {
        var newHeadingId = 1;
        var selectAreaId = '#BenefitsAndFeaturesSection';
        switch (BenefitsAndFeaturesSection) {
            case 'BenefitsAndFeaturesSection': selectAreaId = '#BenefitsAndFeaturesSection'; break;
            case 'c': selectAreaId = '#BenefitsAndFeaturesSection'; break;
            case 'd': selectAreaId = '#BenefitsAndFeaturesSection'; break;
            case 'e': selectAreaId = '#BenefitsAndFeaturesSection'; break;
        }
        $(selectAreaId + ' table').each(function (i, j) {
            var thisId = Number($(j).find('th:first-child').html().substr(8, ($(j).find('th:first-child').html().length - 8)));
            if (thisId > newHeadingId)
                newHeadingId = thisId;
        });
        return newHeadingId + 1;
    }

}



