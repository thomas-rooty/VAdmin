<?php
$url = "http://127.0.0.1/veiko/api/user/3"; // modifier le produit 1
$data = array('users_name' => 'JeMappellePost', 'users_address' => 'JhabiteAPost', 'users_email' => 'methode@post.com', 'users_password' => 'postpw', 'users_birthday' => '2021-01-01', 'user_group' => 'user');
$ch = curl_init($url);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "PUT");
curl_setopt($ch, CURLOPT_POSTFIELDS,http_build_query($data));
$response = curl_exec($ch);
var_dump($response);
if (!$response) 
{
    return false;
}
?>