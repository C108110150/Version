

var table= $nt.formData.table1.body;//顯示資料的表格
for (i = 0; i < table.length; i++) {
    var DeptID = table[i].DeptID;
    var para = { "DeptID": DeptID };
    console.log(para);
        $nt.dps.exec("", "EFD2F966-B433-4468-85B1-40C6004E7FEE", para, null)//將寫好的DPS編碼放入exec
            .then((resolve) => {
                console.log(resolve);
                var AssetsID = resolve[0]["AccountID"];//欄位名稱
                var MemberName = resolve[0]["MemberName"];//欄位名稱
                console.log(AssetsID);
                console.log(MemberName);
                $nt.currentData.hidden2=AssetsID;
                $nt.currentData.hidden3=MemberName;

            });
    }
