<?php

    use PHPMailer\PHPMailer\PHPMailer;
    use PHPMailer\PHPMailer\Exception;

    require '../services/src/Exception.php';
    require '../services/src/PHPMailer.php';
    require '../services/src/SMTP.php';

    $mail = new PHPMailer(true);

    $mail->isSMTP();
    $mail->Host = 'smtp.gmail.com';
    $mail->SMTPAuth = true;
    $mail->Username = 'clients.profsoftwares@gmail.com';
    $mail->Password = 'fkgnyslpoesgjkjw';
    $mail->SMTPSecure = 'ssl';
    $mail->Port = 465;

    $mail->setFrom('clients.profsoftwares@gmail.com');
    $mail->addAddress('proficientsoftwaresolutions@gmail.com');
    $mail->isHTML(true);

    $mail->Subject = $_POST["subject"];
    $mail->Body = '<br>New email from : <strong>' .$_POST["name"] . '</strong><br><br>Message: ' . $_POST["message"] . '<br><br>Email address : ' . $_POST["email"];

    $mail->send();
?>