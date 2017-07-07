var Randomizer = { 
    Random: (new java.util.Random(Util.getWorldSeed())) 
};
Randomizer.ForCoords = function(x, z){
    var seed = Number(Util.getWorldSeed());
    var coord = Number(Math.round(x) + "" + Math.abs(Math.round(z)*2));
    this.Random = new java.util.Random(seed + coord);
}
Randomizer.GaussRandom = function(max, depth){
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