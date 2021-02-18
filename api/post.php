<?php
    $url = 'http://localhost/veiko/api/user';
    $data = array('users_name' => 'JeMappellePost', 'users_address' => 'JhabiteAPost', 'users_email' => 'methode@post.com', 'users_password' => 'postpw', 'users_birthday' => '2021-01-01', 'user_group' => 'user');

    // use key 'http' even if you send the request to https://..
	$options = array(
		'http' => array(
			'header'  => "Content-type: application/x-www-form-urlencoded\r\n",
			'method'  => 'POST',
			'content' => http_build_query($data)
		)
	);
	$context  = stream_context_create($options);
	$result = file_get_contents($url, false, $context);
	if ($result === FALSE) { /* Handle error */ }

	var_dump($result);
?>