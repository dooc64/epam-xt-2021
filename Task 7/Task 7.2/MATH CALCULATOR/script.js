function mathCalculator(string){
    let result = 0,
			matchArr = [],
			searchPattern = /\-?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;

		matchArr = string.match(searchPattern);
    if(string[string.length - 1] !== '='){
        return;
    }

    if(matchArr[0]*1+"" !== "NaN") {
        result += matchArr[0]*1;
    }

    for(let i = 0; i < matchArr.length; i++) {
        switch(matchArr[i]) {
            case "+": result += matchArr[i+1] * 1; break;
            case "-": result -= matchArr[i+1] * 1; break;
            case "*": result *= matchArr[i+1] * 1; break;
            case "/": result /= matchArr[i+1] * 1; break;
            case "=": break;
            default: continue; 
        }
    }
   
    return result;
}
