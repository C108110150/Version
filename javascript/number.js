

$nt.formData.isNumber = function(n){
    return Number(n)=== n;
}

// Convert to number and skip thousandth comma
$nt.formData.parseNumber = function(txt) {
    var noCommaTxt = txt.replace(/[,]/g, "");
    var number = parseFloat(noCommaTxt, 10);

    if (!$nt.formData.isNumber(number))
        return 0;
    return number;
}

// Convert number to thousandth comma text
$nt.formData.toThousandFormat = function(numInp, intDecimalPlaces) {
    if (intDecimalPlaces == undefined || intDecimalPlaces == null)
        intDecimalPlaces = 0;

    var tempNumber = Number(numInp.toFixed(intDecimalPlaces));
    var formatted = tempNumber.toLocaleString('en-US');
    return formatted;
}






if ($nt.formData.CnyRate==1.00) {

    for(i=0; i<$nt.formData.table3.body.length;i++){
       
        const input = $nt.formData.table3.body[i].PayAmount_Show;
         $nt.formData.table3.body[i].PayAmount_Show = 0;
        $nt.formData.table3.body[i].PayAmount = 0;
    	if(input){   
    	    const val = $nt.formData.parseNumber(input);

            const result = $nt.formData.toThousandFormat(Math.floor(val));
            const Amount = $nt.formData.parseNumber(result);
            
    		$nt.formData.table3.body[i].PayAmount_Show = result;
            $nt.formData.table3.body[i].PayAmount = Amount;
	}
}
}
else{

for(i=0; i<$nt.formData.table3.body.length;i++){
    const input = $nt.formData.table3.body[i].PayAmount_Show;
	if(input){   
	    const val = $nt.formData.parseNumber(input);

        const result = $nt.formData.toThousandFormat(val,2);
        const Amount = $nt.formData.parseNumber(result);

        
		$nt.formData.table3.body[i].PayAmount_Show = result;
        $nt.formData.table3.body[i].PayAmount = Amount;
	}
}

}