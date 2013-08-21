<?php
	if(isset($_POST['submit']))
	{
		$number = $_POST['number'];
		$sign = $_POST['sign'];
		$anotherNumber = $_POST['anotherNumber'];
		if($sign == '*')
		{
			echo $number * $anotherNumber; 
		}
		elseif($sign == '/') 
		{
			echo $number / $anotherNumber; 
		}
		elseif($sign == '+') 
		{
			echo $number + $anotherNumber; 
		}
		elseif($sign == '-') 
		{
			echo $number - $anotherNumber; 
		}
	}
	else
	{
		echo "Form is not submit";
	}
?>