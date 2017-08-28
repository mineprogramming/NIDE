var Timers = {
    Once: new Array(),
    Repetetive: new Array()
};

Timers.modTick = function(){
    this.Once = this.Once.filter(function(item){
        item.Time--;
        if(item.Time <= 0){
            item.Action(item.Id, item.Data);
            return false;
        }
        else
            return true;
    });
    this.Repetetive.forEach(function(item){
        item.Time--;
        if(item.Time <= 0){
            item.Action(item.Id, item.Data);
            item.Time = item.Period;
        }
    });
}

Timers.addOnce = function(id, time, action, data){
    this.Once.push({Id:id, Time:time, Action:action, Data:data});
}

Timers.addRepetiteve = function(id, time, action, data){
    this.Repetetive.push({Id:id, Period:time, Time:time, Action:action, Data:data});
}

Timers.remove = function(id){
    this.Repetetive = this.Repetetive.filter(function(item){
        if(item.Id == id){
            return false;
        }
        else{
            return true;
        }
    });
    this.Once = this.Once.filter(function(item){
        if(item.Id == id){
            return false;
        }
        else{
            return true;
        }
    });
}