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
        Object.keys(obj).forEach(key => {
            dict[id][key] = obj[key];
        });
    }

    this.replaceById = function(id, obj){
        dict.set(id, obj)
    }
}







let users = new usersList();
let person = {name : "maksim", age : 16}
let person2 = {name : "ivan", age : 16}
let person3 = {name : "danil", age : 32}
let person4 = {name : "danya", age : 16}
let person5 = {name : "sasha", age : 16}



users.add(person)
users.add(person2)
users.add(person3)
users.add(person4)
users.add(person5)



users.updateById("ID2", person5)


let all = users.getAll();

console.log(all);