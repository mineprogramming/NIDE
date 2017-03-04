var Randomizer = {
    Random: (new java.util.Random(Util.getWorldSeed()))
};

Randomizer.GaussRandom = function(max, depth){
    if (typeof depth === 'undefined') {
        depth = 1;
    }
    var result = 0;
    for(var i = 0; i < depth; i++){
        result += this.Random.nextInt(max * 2) - max;
    }
    return Math.round(Math.abs(result / depth));
};

Randomizer.Double = function(){
    return this.Random.nextDouble();
}

Randomizer.Int = function(max){
    return this.Random.nextInt(max);
}