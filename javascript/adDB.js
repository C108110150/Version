const CSID = $nt.formData.CSUser;
$nt.dps.exec("", "0C435DB1-70DD-43D6-8227-4B9FCF6175AD",{}, null).then((resolve) => {//將DPS全部帶出來判斷，中間的空陣列不能刪，刪了會錯誤
    console.log(resolve)
      const result = resolve.find(item => item.AccountID === CSID);
      $nt.formData.CSUserName = result.MemberName;    
});
