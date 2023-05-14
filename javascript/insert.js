let table = $nt.formData.table1.body;//選擇要寫入資料的表格
table.forEach(function(item, index) {
        let para = item;
        console.log(item)
        // para["RequisitionID"] = $nt.bpmData.requisitionID;//添加表單ID
        //將DPS編碼放在exec
        $nt.dps.exec("", "26D9822D-622A-45EE-BA5D-43BDAD8C09D7", item, null).then((resolve) => {
            console.log(resolve)
            //do something
        });
    });
