function usersList(){
    var dict = new Map();
    let currentId = 0;
    

    this.add = function(obj){
        id = "ID" + currentId;
        currentId++;
        dict.set(id, obj)
    }

    this.getById = function(id){
        if(dict.get(id) !== undefined)
            return dict.get(id);

        return null;
    }

    this.getAll = function(){
        return dict;
    }

    this.deleteById = function(id){
        let obj = dict[id];
        delete dict[id];
        return obj;
    }

    this.updateById = function(id, obj){
        dict.set(id, obj);
    }

    this.replaceById = function(id, obj){
        dict.set(id, obj);
    }
}



