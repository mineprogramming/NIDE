var FileAPI = {
	File:java.io.File,
	FileReader:java.io.FileReader,
	BufferedReader:java.io.BufferedReader,
	InputStreamReader :java.io.InputStreamReader,
	FIS : java.io.FileInputStream,
	FOS:java.io.FileOutputStream,
	String:java.lang.String,
	StringBuilder:java.lang.StringBuilder,
	
	
	//Выбрать файл Name по пути dir
	select:function(dir,Name){
		return (new this.File(dir,Name));	
	},
	//Создать папку newDirName по пути dir
	createNewDir:function(dir, newDirName){
		return (new this.File(dir, newDirName).mkdir());
	},
	//Существует ли файл file
	exists:function(file){
		return file.exists();
	},
	//Создать файл name по пути path
	create:function(path, name){
		new this.File(path, name).createNewFile();
		return this.File;
	},
	//Удалит файл/папку по пути path
	delete:function(path){
		try {
            var filed = new java.io.File(path);
            if (filed.isDirectory()) {
                var directoryFiles = filed.listFiles();
                for (var i in directoryFiles) {
                    FileAPI.delete(directoryFiles[i].getAbsolutePath());
                }
                filed.delete();
            }
            if (filed.isFile()) {
                filed.delete();
            }
        } catch (e) {
           print("FileAPI.Delete:"+e);
        }
		
	},
	
	//Прочитать файл selectedFile
	read: function(selectedFile) {
        var readed = (new FileAPI.BufferedReader(new FileAPI.FileReader(selectedFile)));
        var data = new FileAPI.StringBuilder();
        var string;
        while ((string = readed.readLine()) != null) {
            data.append(string);
            data.append('\n');
        }
        return data.toString();
    },
    //Прочитать строку line в файле selectedFile
	readLine: function(selectedFile, line) {
        var readT = new FileAPI.read(selectedFile);
        var lineArray = readT.split('\n');
        return lineArray[line - 1];
    },
	
	//Записать text в файле selectedFile
	write: function(selectedFile, text) {
        FileAPI.rewrite(selectedFile, (new FileAPI.read(selectedFile)) + text);
    },
	rewrite: function(selectedFile, text) {
        var writeFOS = new FileAPI.FOS(selectedFile);
        writeFOS.write(new FileAPI.String(text).getBytes());
    },
    
	//Получить список файлов которые заканчиваются на lookFor по пути path 
	readFileList: function(path, lookFor) {
        var file = FileAPI.File(path);
        var Files = file.listFiles();
        var fileList = [];
        if (Files == null) return false;
		
        for (var a in Files) {
			
            var fileName2 = Files[a].getName();
			if(Files[a].isFile()){
				if (lookFor != null) {
                    if (typeof(lookFor) == "string") {
                        if (!fileName2.endsWith(lookFor)) {
                            continue;
                        }else{
                        	fileList.push(fileName2);
                        }
                    } else
                    if (lookFor instanceof Array) {
                        var index = fileName2.lastIndexOf(".");
                        if (index == -1) continue;
                        for (var b in lookFor) {
                            if (lookFor[b] == fileName2.substring(index)) {
                                fileList.push(fileName2);
                            }
                        }
                        continue;
                    }
                }
			}
        }
        fileList = fileList.sort();
        return fileList;
    },
    //Получить список папок по пути path
	readFolderList: function(path) {
        var file = FileAPI.File(path);
        var Files = file.listFiles();
        var folderList = [];
        if (Files == null) return false;
		
        for (var a in Files) {
            var fileName2 = Files[a].getName();
            if (Files[a].isDirectory()) {
                folderList.push(fileName2);
            }
        }
        folderList = folderList.sort();
        return folderList;
    }
	
};
