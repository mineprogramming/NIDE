Plugin.registerMenuButton("Create Mod Description", function(){
    var items = [];
    var blocks = [];
    var recipes = [];

    var ItemID = [];
    var BlockID = [];

    // Function used to simplify item creation capturing
    function createItem(id, name, texture, data){
        data = data || {};
        data.stack = data.stack || 64;

        if(data.isTech){
            return;
        }

        texture = {name: texture.name, data: texture.meta || texture.data || 0};
        texture.file = texture.name + "_" + texture.data + ".png";

        ItemID[id] = "ItemID." + id;
        items.push({
            id: id, 
            name: name,
            type: "regular",
            texture: texture,
            data: data
        });
    }

    // Function used to simplify food item creation capturing
    function createFoodItem(id, name, texture, data){
        data = data || {};
        data.stack = data.stack || 64;
        data.food = data.food || 1;

        if(data.isTech){
            return;
        }

        texture = {name: texture.name, data: texture.meta || texture.data || 0};
        texture.file = texture.name + "_" + texture.data + ".png";

        ItemID[id] = "ItemID." + id;
        items.push({
            id: id, 
            name: name,
            type: "food",
            texture: texture,
            data: data
        });
    }


    // Function used to simplify armor item creation capturing
    function createArmorItem(id, name, texture, data){
        data = data || {};
        data.stack = data.stack || 1;
        data.durability = data.food || 1;
        data.armor = data.armor || 1;
        data.type = data.type || "unknown";

        if(data.isTech){
            return;
        }

        texture = {name: texture.name, data: texture.meta || texture.data || 0};
        texture.file = texture.name + "_" + texture.data + ".png";

        ItemID[id] = "ItemID." + id;
        items.push({
            id: id, 
            name: name,
            type: "armor",
            texture: texture,
            data: data
        });
    }

    // Function used to simplify throwable item creation capturing
    function createThrowableItem(id, name, texture, data){
        data = data || {};
        data.stack = data.stack || 64;

        if(data.isTech){
            return;
        }

        texture = {name: texture.name, data: texture.meta || texture.data || 0};
        texture.file = texture.name + "_" + texture.data + ".png";

        ItemID[id] = "ItemID." + id;
        items.push({
            id: id, 
            name: name,
            type: "throwable",
            texture: texture,
            data: data
        });
    }

    var Block = {
        createSpecialType: function(params, name){
            var type = {
                base: 20,
                destroytime: 1,
                explosionres: 3,
                lightlevel: 0,
                lightopacity: 0,
                renderlayer: 9,
                rendertype: 0,
                solid: false
            }

            for(var i in params){
                type[i] = params[i];
            }

            if(name){
                specialTypes[name] = type;
            }

            return type;
        }
    }

    var Item = {
        getMaxDamage: function(id){
            return 0;
        }
    }

    var ChargeItemRegistry = {
        transportEnergy: function(){}
    }

    var NANO_SABER_DURABILITY = 0;

    var specialTypes = {
        "opaque": Block.createSpecialType({
            solid: true,
            base: 1,
            lightopacity: 15,
            explosionres: 4,
            renderlayer: 3
        }),
    }

    function createBlock(id, variations, type){
        for(var i in variations){
            if(!variations[i].inCreative){
                continue;
            }

            var textureInfo = variations[i].texture;
            var texture = [];
    
            var lastTexture;
            for(var i = 0; i < 6; i++){
                if(textureInfo[i]){
                    texture[i] = {name: textureInfo[i][0], data: textureInfo[i][1] || 0};
                    lastTexture = texture[i];
                } else {
                    texture[i] = {name: lastTexture.name, data: lastTexture.data};
                }
                
                texture[i].file = texture[i].name + "_" + texture[i].data + ".png";
            }
            
            type = type || Block.createSpecialType({});
            
            BlockID[id] = "BlockID." + id;
            blocks.push({
                id: id,
                name: variations[0].name,
                texture: texture,
                type: specialTypes[type]? specialTypes[type]: type
            });
        }        
    }
    var createBlockWithRotation = createBlock;


    function addShaped(result, recipe, components, callback){
        var dimension = (recipe.length > 2 && recipe[0].length > 2)? 3: 2;

        var dictionary = {};
        for(var i = 0; i < components.length; i += 3){
            dictionary[components[i]] = {id: components[i + 1], data: components[i + 2] < 0? 0: components[i + 2]}
        }

        var scheme = [];
        scheme[0] = []; scheme[1] = []; scheme[2] = [];
        for(var i = 0; i < dimension; i++){
            for(var j = 0; j < dimension; j++){
                if(recipe[i] && recipe[i][j]){
                    scheme[i][j] = dictionary[recipe[i][j]];
                } else {
                    scheme[i][j] = {id: 0, data: 0};
                }
            }
        }

        recipes.push({
            result: result,
            dimension: dimension,
            scheme: scheme
        });
    }

    function addShapeless(result, recipe, callback){
        var dimension = recipe.length > 4? 3: 2;

        var scheme = [];
        scheme[0] = []; scheme[1] = []; scheme[2] = [];
        var i = -1;
        var j = 0;
        for(var item in recipe){
            if(j % dimension == 0){
                i++;
                j = 0;
            }
            scheme[i][j] = {id: recipe[item].id, data: recipe[item].data < 0? 0: recipe[item].data || 0};
            j++;
        }

        recipes.push({
            result: result,
            dimension: dimension,
            scheme: scheme
        });
    }


    // Get scripts list
    var directory = Project.getScriptsDirectory();
    var scripts = File.search(directory, "*.js");

    // Read all scripts
    for(var i in scripts){
        scripts[i] = File.read(scripts[i]);
    }

    // Parse items
    for(var i in scripts){
        var script = scripts[i];

        var regexp = /createItem|createFoodItem|createArmorItem|createThrowableItem/g;
        var result = null;

        while ((result = regexp.exec(script)) !== null) {
            var index = result.index;
            var itemString = script.substring(index, script.indexOf(';', index));
            try {
                eval(itemString);
            } catch (error) {
                Nide.warn("Unable to parse item data: " + itemString + "; error: " + error);
            }
        }
    }


    // Parse blocks special types
    for(var i in scripts){
        var script = scripts[i];

        var regexp = /(var\s+([a-zA-Z0-9_]*)\s*=\s*Block\.createSpecialType)|(Block\.createSpecialType)/g;
        var result = null;

        while ((result = regexp.exec(script)) !== null) {
            var index = result.index;
            var typeString = script.substring(index, script.indexOf(';', index));
            try {
                eval(typeString);
            } catch (error) {
                Nide.warn("Unable to parse special type: " + typeString + "; error: " + error);
            }
        }
    }


    // Parse blocks
    for(var i in scripts){
        var script = scripts[i];

        var regexp = /createBlock|createBlockWithRotation/g;
        var result = null;

        while ((result = regexp.exec(script)) !== null) {
            var index = result.index;
            var blockString = script.substring(index, script.indexOf(';', index));
            try {
                eval(blockString);
            } catch (error) {
                Nide.warn("Unable to parse block data: " + blockString + "; error: " + error + "; creating replacement block instead");
                var id = blockString.split("\"")[1];
                createBlock(id, [{
                    name: id.charAt(0).toUpperCase() + id.slice(1),
                    texture: [[id, 0]],
                    inCreative: true
                }], "unknown");
            }
        }
    }


    // Parse recipes
    for(var i in scripts){
        var script = scripts[i];

        var regexp = /addShaped|addShapeless/g;
        var result = null;

        while ((result = regexp.exec(script)) !== null) {
            var index = result.index;
            var recipeString = script.substring(index, script.indexOf(';', index));
            try {
                eval(recipeString);
            } catch (error) {
                Nide.warn("Unable to parse recipe data: " + recipeString + "; error: " + error);
            }
        }
    }

    generateHtml(Project.getDirectory() + "\\ModDocker\\", items, blocks, recipes);
});



function copyFileIfNotExist(from, to){
    if(!File.exists(to)){
        File.copy(from, to);
    }
}


function generateHtml(path, items, blocks, recipes){
    var project = Project.getName();

    var BLOCK_PARAM = {base: "base block", destroytime: "destroy time", explosionres: "explosion resistance", lightlevel: "light level", lightopacity: "opacity", renderlayer: "render layer", rendertype: "render type", solid: "is solid"}

    function findItemTexture(destination, texture){
        // mod assets with data
        var textures = File.search(Project.getItemsDirectory(), texture.file);
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }

        // mod assets without data
        textures = File.search(Project.getItemsDirectory(), texture.name + ".png");
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }

        // vanilla textures
        textures = File.search("textures\\minecraft-items\\", texture.name + ".png");
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }
        Nide.warn("Unable to find item texture: " + texture.file);
        copyFileIfNotExist("textures\\ic_default.png", destination + texture.file);
    }


    function findBlockTexture(destination, texture){
        // mod assets with data
        var textures = File.search(Project.getBlocksDirectory(), texture.file);
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }

        // mod assets without data
        textures = File.search(Project.getBlocksDirectory(), texture.name + ".png");
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }

        // vanilla textures
        textures = File.search("textures\\minecraft-blocks\\", texture.name + ".png");
        if(textures.length > 0){
            copyFileIfNotExist(textures[0], destination + texture.file);
            return;
        }
        Nide.warn("Unable to find block texture: " + texture.file + "; using default texture instead");
        copyFileIfNotExist("textures\\ic_default.png", destination + texture.file);
    }


    // Create folder for assets
    File.createDirectory(path + project + "\\items-opaque\\");
    File.createDirectory(path + project + "\\terrain-atlas\\");
    File.createDirectory(path + project + "\\vanilla\\");

    // Generate HTML

    // Header
    var html = "<html><head><meta charset=\"utf-8\"><title>ModDocker: " + project + "</title></head><body>";

    // Table of contents
    html += "<h1 id=\"contents\">Table of contents</h1>";
    html += "<ul><li><a href=\"#items\">Items</a></li>";
    html += "<li><a href=\"#blocks\">Blocks</a></li>";
    html += "<li><a href=\"#recipes\">Recipes</a></li></ul>";

    // Write items data
    html += "<h1 id=\"items\">Items</h1>";
    html += "<a href=\"#contents\">to contents</a>";
    html += "<p>" + project + " contains " + items.length + " items:" + "</p>";
    for(var i in items){
        var item = items[i];
        html += "<div class=\"block\">";
        html += "<h3 id=\"ItemID." + item.id + "\">" + item.name + "</h3>";
        html += "<img src=\"" + project + "/items-opaque/" + item.texture.file + "\" class=\"minecraft-item\">";
        html += "type: " + item.type + "<br/>";
        html += "id: " + item.id + "<br/>";
        html += "stack: " + item.data.stack + "<br/>";
        switch(item.type){
            case "food":
                html += "food: " + item.data.food + "<br/>";
                break;
            case "armor":
                html += "armor type: " + item.data.type + "<br/>";
                html += "armor: " + item.data.armor + "<br/>";
                html += "durability: " + item.data.durability + "<br/>";
                break;
        }
        html += "</div>";
        findItemTexture(path + project + "\\items-opaque\\", item.texture);
    }

    // Write blocks data
    html += "<h1 id=\"blocks\">Blocks</h1>";
    html += "<a href=\"#contents\">to contents</a>";
    html += "<p>" + project + " contains " + blocks.length + " blocks:" + "</p>";
    for(var i in blocks){
        var block = blocks[i];
        html += "<div class=\"block\">";
        html += "<h3 id=\"BlockID." + block.id + "\">" + block.name + "</h3>";

        html += "<div class=\"_3d-wrapper\"><div class=\"container\">";
        html += "<div class=\"back side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[2].file + "\');\"></div>";
        html += "<div class=\"left side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[4].file + "\');\"></div>";
        html += "<div class=\"right side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[5].file + "\');\"></div>";
        html += "<div class=\"top side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[1].file + "\');\"></div>";
        html += "<div class=\"bottom side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[0].file + "\');\"></div>";
        html += "<div class=\"front side\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + block.texture[3].file + "\');\"></div>";
        html += "</div></div>";

        for(var i = 0; i < 6; i++){
            // html += "<img src=\"" + project + "/terrain-atlas/" + block.texture[i].file + "\" class=\"minecraft-item\">";
            findBlockTexture(path + project + "\\terrain-atlas\\", block.texture[i]);
        }
        
        html += "id: " + block.id + "<br/>";
        
        if(block.type != "unknown"){
            for(var i in block.type){
                html += (BLOCK_PARAM[i]? BLOCK_PARAM[i]: i) + ": " + block.type[i] + "<br/>";
            }
        }

        html += "</div>";
    }


    function getItemById(id){
        id = id.substring(id.indexOf('.') + 1);
        for(var i in items){
            if(items[i].id == id){
                return items[i];
            }
        }
    }

    function getBlockById(id){
        id = id.substring(id.indexOf('.') + 1);
        for(var i in blocks){
            if(blocks[i].id == id){
                return blocks[i];
            }
        }
    }

    function getSlot(item){
        if(!item || item.id == 0){
            return "<span class=\"invslot\" style=\"width:32px;height:32px\"><br></span>";
        }

        var texture;
        if(typeof item.id == "number"){
            var vanillaFile = item.id + '_' + item.data + ".png";
            copyFileIfNotExist("icons\\items\\" + vanillaFile, path + project + "\\vanilla\\" + vanillaFile);
            texture = project + "/vanilla/" + vanillaFile;
            return "<span class=\"invslot\" style=\"width:32px;height:32px\"><span class=\"invslot-item\" data-minetip-title=\"Железный слиток\">" 
                + "<a href=\"#\"><span class=\"sprite inv-sprite\" style=\"background-image: url('" + texture + "');\"><br></span></a></span></span>";
        } else {
            if(item.id && item.id.indexOf("ItemID") == 0){
                texture = project + "/items-opaque/" + getItemById(item.id).texture.file;
                return "<span class=\"invslot\" style=\"width:32px;height:32px\"><span class=\"invslot-item\" data-minetip-title=\"Железный слиток\">" 
                    + "<a href=\"#" + item.id + "\"><span class=\"sprite inv-sprite\" style=\"background-image: url('" + texture + "');\"><br></span></a></span></span>";
            } else if(item.id && item.id.indexOf("BlockID") == 0){
                texture = getBlockById(item.id).texture;
                return "<span class=\"invslot\" style=\"width:32px;height:32px\"><span class=\"invslot-item\" data-minetip-title=\"Железный слиток\">" 
                    + "<a href=\"#" + item.id + "\"><div class=\"_3d-wrapper\"><div class=\"container-small\">"
                    + "<div class=\"back side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[2].file + "\');\"></div>"
                    + "<div class=\"left side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[4].file + "\');\"></div>"
                    + "<div class=\"right side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[5].file + "\');\"></div>"
                    + "<div class=\"top side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[1].file + "\');\"></div>"
                    + "<div class=\"bottom side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[0].file + "\');\"></div>"
                    + "<div class=\"front side-small\" style=\"background-image: url(\'" + project + "/terrain-atlas/" + texture[3].file + "\');\"></div>"
                    + "</div></div></a></span></span>";
            } else {
                Nide.warn("Cannot find item with given id: " + item.id);
                return "<span class=\"invslot\" style=\"width:32px;height:32px\"><br></span>";
            }
        }
        

        
    }

    // Write recipes data
    html += "<h1 id=\"recipes\">Recipes</h1>";
    html += "<a href=\"#contents\">to contents</a>";
    html += "<p>" + project + " contains " + recipes.length + " recipes:" + "</p>";
    for(var i in recipes){
        var recipe = recipes[i];
        html += "<div class=\"gui-set craft-gui gui\">"
            + "<span class=\"mcui-input\">"
                + "<span class=\"mcui-row\">" 
                    + getSlot(recipe.scheme[0][0])
                    + getSlot(recipe.scheme[0][1])
                    + getSlot(recipe.scheme[0][2])
                + "</span><span class=\"mcui-row\">" 
                    + getSlot(recipe.scheme[1][0])
                    + getSlot(recipe.scheme[1][1])
                    + getSlot(recipe.scheme[1][2])
                + "</span><span class=\"mcui-row\">"
                    + getSlot(recipe.scheme[2][0])
                    + getSlot(recipe.scheme[2][1])
                    + getSlot(recipe.scheme[2][2])
                + "</span>"
            + "</span>"
            + "<span class=\"mcui-arrow\"><br></span>"
            + "<span class=\"mcui-output\">" 
            + getSlot(recipe.result)
            + "</span></div>";
    }

    copyFileIfNotExist("textures\\craft-bg.png", path + project + "\\craft-bg.png");
    copyFileIfNotExist("textures\\craft-arrow.png", path + project + "\\craft-arrow.png");

    // Footer
    html += "<style>.minecraft-item{width: 48px; float: left; padding-right: 15px; padding-left: 5px; image-rendering: pixelated; image-rendering: optimizeSpeed; -ms-interpolation-mode: bicubic;}"
        + ".block{display: flow-root;}" 
        + "._3d-wrapper {display: block; float: left; padding-left: 10px; padding-right: 20px;-webkit-perspective: 800px; perspective: 800px; -webkit-perspective-origin: center -5em;}"
        + ".container {width: 48px; height: 48px; -webkit-transform-style: preserve-3d; transform-style: preserve-3d; -webkit-animation: rotate 10s infinite linear; animation: rotate 10s infinite linear; image-rendering: pixelated; image-rendering: optimizeSpeed; -ms-interpolation-mode: bicubic;}"
        + ".container-small {width: 20px; height: 20px; -webkit-transform-style: preserve-3d; transform-style: preserve-3d; image-rendering: pixelated; image-rendering: optimizeSpeed; -ms-interpolation-mode: bicubic;position: relative; top: 5px; left: -4px; transform: rotateY(-20deg) rotateX(-5deg);}"
        + ".side { position: absolute; width: 48px; height: 48px; background-size:100% 100%;}"
        + ".side-small { position: absolute; width: 20px; height: 20px; background-size:100% 100%;}"
        + ".back {-webkit-transform:translateZ(-24px); transform:translateZ(-24px);}" 
        + ".side-small.back {-webkit-transform:translateZ(-10px); transform:translateZ(-10px);}"
        + ".front { -webkit-transform: translateZ(24px); transform: translateZ(24px);}"
        + ".side-small.front { -webkit-transform: translateZ(10px); transform: translateZ(10px);}"
        + ".top { -webkit-transform: translateY(-24px) rotateX(90deg); transform: translateY(-24px) rotateX(90deg);}"
        + ".side-small.top { -webkit-transform: translateY(-10px) rotateX(90deg); transform: translateY(-10px) rotateX(90deg);}"
        + ".bottom { -webkit-transform: translateY(24px) rotateX(90deg); transform: translateY(24px) rotateX(90deg);}"
        + ".side-small.bottom { -webkit-transform: translateY(10px) rotateX(90deg); transform: translateY(10px) rotateX(90deg);}"
        + ".left { -webkit-transform: translateX(-24px) rotateY(90deg); transform: translateX(-24px) rotateY(90deg);}"
        + ".side-small.left { -webkit-transform: translateX(-10px) rotateY(90deg); transform: translateX(-10px) rotateY(90deg);}"
        + ".right { -webkit-transform: translateX(24px) rotateY(90deg); transform: translateX(24px) rotateY(90deg);}" 
        + ".side-small.right { -webkit-transform: translateX(10px) rotateY(90deg); transform: translateX(10px) rotateY(90deg);}" 
        + "@-webkit-keyframes rotate { 100% { -webkit-transform: rotateY(360deg); transform: rotateY(360deg); }} @keyframes rotate {100% { -webkit-transform: rotateY(360deg); transform: rotateY(360deg); }}"
        + ".craft-gui {width: 282px; height: 140px; background-image: url('" + project + "/craft-bg.png'); position: relative;}"
        + ".craft-gui > .mcui-input {position: relative; top: 16px;} .craft-gui > * {display: inline-block; vertical-align: middle;}"
        + ".craft-gui .mcui-row {display: block;} .gui { text-align: center; display: inline-block; margin: 10px;}"
        + ".invslot {position: relative; display: inline-block; background: #8B8B8B no-repeat center center / 32px 32px; border: 2px solid; border-color: #373737 #FFF #FFF #373737; width: 32px; height: 32px; font-size: 16px; line-height: 1; text-align: left; vertical-align: bottom; }"
        + ".craft-gui > .mcui-arrow { background: url('" + project + "/craft-arrow.png') no-repeat; width: 32px; height: 26px; margin: 0 22px; position: relative; top: 16px;}"
        + ".craft-gui > .mcui-output { position: relative; top: 16px; }"
        + ".invslot-item, .invslot-item > a:first-child { position: relative; display: block; margin: -2px; padding: 2px; }"
        + ".inv-sprite { width: 30px; height: 30px; vertical-align: middle; image-rendering: pixelated; image-rendering: optimizeSpeed; -ms-interpolation-mode: bicubic; margin: 1px;}"
        + ".sprite { display: inline-block; vertical-align: text-top; background-repeat: no-repeat; background-size:100% 100%;}"
        + "</style></body></html>";

    // Ensure ModDocker directory exists
    File.createDirectory(path);

    // Write HTML
    File.write(path + project + ".html", html);


    Nide.log("Successfully generated mod documentation!");
}
