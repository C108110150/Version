const array = $nt.formData.table1.body;//更改要用的表格
const data = $nt.callbackData.formData;
let cosigns = $nt.formData.cosigns;//更改要存加簽的欄位名稱

if ( array.length == 1){
    const con = $nt.formData.table1.body[0].cosign_DeptName;//更改要用的表格的部門名稱欄位
    if(con == ""){
        array.pop();
    }
}
data.map((value) => {
    var i=array.length+1;
    if (i <= 6) {
        const guid = $nt.formData.GetGUID();
        const obj = {};
        obj["guid"] = guid;
        obj["cosign_DeptName"] = value["deptName"];   //obj[deptName欄位名稱]
        obj["cosign_DeptID"] = value["deptID"];       //value[回應參數設定]
        obj["cosign_Name"] = value["accountName"];
        obj["cosign_ID"] = value["accountID"];
        array.push(obj);
        cosigns += "," + value["accountID"] + "@" + value["deptID"];
}});
$nt.formData.table1.body = 
    array.filter((element, index, array) => {
    return index === array.findIndex(item => item.cosign_ID === element.cosign_ID);//更改存人員ID的欄位名稱
});
cosigns = cosigns.slice(1);
$nt.formData.cosigns = cosigns;//更改要存加簽的欄位名稱





