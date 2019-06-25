
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
</head>
<body>
    <div> 
        <form method="post" action="/test/PostLogin">
            <input type="text" name="Name" />
            <input type="text" name="Pwd" />
            <input type="submit" value="提交" />
        </form>
    </div>
</body>
</html>
