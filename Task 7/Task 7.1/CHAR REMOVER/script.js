function charRemover(a){
    a = a.toLowerCase();
    uArray = a.split('');
    for(let i = 0; i < uArray.length; i++){
        for(let y = uArray.length; y > i; y--){
            if(uArray[i] == uArray[y])
                uArray.splice(i, 1);
        }
    }
    return uArray.join('');
}