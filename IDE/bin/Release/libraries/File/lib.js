var FileReader = java.io.FileReader;
var BufferedReader = java.io.BufferedReader;
var InputStreamReader = java.io.InputStreamReader;
var FIS = java.io.FileInputStream;
var FOS = java.io.FileOutputStream;
var String = java.lang.String;
var StringBuilder = java.lang.StringBuilder;

var _f = java.io.File;

var File = function(dir,name){
	var file;
	if(typeof(name)!='string'){
		file = new _f(dir);
	}else{
		file = new _f(dir, name);	
	}
	
	this.isDirectory = function(){
		return file.isDirectory();
	}
	this.isFile = function(){
		return file.isFile();
	}
	this.getAbsolutePath = function(){
		return file.getAbsolutePath();
	}
	
	if(this.isDirectory){
		this.path = this.getAbsolutePath();
	}else if(this.isFile){
		var a = this.getAbsolutePath().split("/");
		a.length = a.length-1;
		this.path = a.join("/");
	}
	
	this.create = function(){
		return file.createNewFile();
	}
	this.createDirectory = function(){
		return file.mkdirs();
	}
	this.delete = function(){
		return file.delete();
	}
	this.exists = function(){
		return file.exists();
	}
	this.getName = function(){
		return file.getName();
	}
	this.getPath = function(){
		return file.getPath();
	}
	this.list = function(){
		return file.list();
	}
	this.listFiles = function(a,b){
			var list = this.list();
			if(!a)a = File.ALL;
			if(!b)b=-1;
			var files = [];
			for(var i = 0; i < list.length; i++){
				var _ff = new File(this.path+"/"+list[i]);
				switch(a){
					
					case File.ALL:
					 if(b==-1)
					 	 files.push(_ff);
					 	else
				 	 if( _ff.getName().endsWith(b))
					  files.push(_ff);
					break;
					case File.DIR:
					 if(_ff.isDirectory())
					  if(b==-1)
					 	  files.push(_ff);
					 	 else
					 	 if( _ff.getName().endsWith(b))
					 	 files.push(_ff);
					 
					break;
					case File.FILE:
					 if(_ff.isFile())
					 	 if(b==-1)
					 	  files.push(_ff);
					 	 else
					 	 if( _ff.getName().endsWith(b))
					 	 files.push(_ff);
					 
					break;
				}
				
			}
			return files;
	}
	this.readLines=function(){
		return this.read().split("\n")
	}
	this.read = function(){
		var readed = (new BufferedReader(new FileReader(file)));
		var data = new StringBuilder();
		//var data;
		var string;
        while ((string = readed.readLine()) != null) {
			data.append(string);
			data.append('\n');
        }
        return data.toString();
        //return data;
	}
	this.readLine = function(line){
		var read = this.read().split("\n");
		return read[line-1];
	}
	this.readLineText = function(text,sp){
		if(typeof(sp)!='string') sp=":";
		
		var readerRLT = new BufferedReader(new InputStreamReader(new FIS(file)));
        var readRLT;
		var textRLT;
        while ((readRLT = readerRLT.readLine()) != null) {
            if (readRLT.split(sp)[0] == text) {
                textRLT = readRLT.split(sp)[1];
				return textRLT;
                break;
            }
        }
        readerRLT.close();
		return false;
	}
	
	this.rewrite = function(text){
		var writeFOS = new FOS(file);
        writeFOS.write(new String(text).getBytes());
	}
	this.write = function(text){
		this.rewrite(this.read()+text);
	}
	
};

File.FILE = "file";
File.DIR = "dir";
File.ALL = "all";
File.readAssets = function(file){
	var readerRLT = new BufferedReader(new InputStreamReader(ModPE.openInputStreamFromTexturePack(file)));
		var readRLT;
		var text="";
		while ((readRLT = readerRLT.readLine()) != null){
			text = text+readRLT+"\n";
		}
		return text;
};
File.Path = {};
File.Path.sdcard = android.os.Environment.getExternalStorageDirectory() + "/";
File.Path.minecraft = File.Path.sdcard + "games/com.mojang/minecraftpe/";