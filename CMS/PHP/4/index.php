<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" />
	<script src="formValidation.js"></script>
</head>
<body>
<div style="color: red;" id="result">
</div>
<form id="myForm" action="form.php" method="POST" onsubmit="return validate('result');">
	<label for="number">Number:</label>
	<br />
	<input type="text" id="number" name="number" />
	<br />
	<label for="sign">Sign:</label>
	<br />
	<input type="text" id="sign" name="sign" />
	<br />
	<label for="anotherNumber">Another number:</label>
	<br />
	<input type="text" id="anotherNumber" name="anotherNumber" />
	<br />
	<input type="submit" id="submit" name="submit" />
</form>
</body>
</html>