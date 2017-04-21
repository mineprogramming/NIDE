var Timers = {
    Once: new Array(),
    Repetetive: new Array()
};

Timers.modTick = function(){
    this.Once = this.Once.filter(function(item){
        item.Time--;
        if(item.Time <= 0){
            item.Action();
            return false;
        }
        else
            return true;
    });
    this.Repetetive.forEach(function(item){
        item.Time--;
        if(item.Time <= 0){
            item.Action();
            item.Time = item.Period;
        }
    });
}

Timers.addOnce = function(id, time, action){
    this.Once.push({Id:id, Time:time, Action:action});
}

Timers.addRepetiteve = function(id, time, action){
    this.Repetetive.push({Id:id, Period:time, Time:time, Action:action});
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