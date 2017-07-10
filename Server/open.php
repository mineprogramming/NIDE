<?php

$file_counter = "opens.html";

$fp = fopen($file_counter, "r");
$counter = fread($fp, filesize($file_counter));
fclose($fp);

$counter++;

$fp = fopen($file_counter, "w");
fwrite($fp, $counter);
fclose($fp); 

?>