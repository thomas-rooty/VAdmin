<?php
    //Se connecter à la BDD
    include("db_connect.php");
    $request_method = $_SERVER["REQUEST_METHOD"];

    function getUsers()
    {
      global $conn;
      $query = "SELECT * FROM users";
      $response = array();
      $result = $conn->query($query);
      while($row = $result->fetch_assoc())
      {
        $response[] = $row;
      }
      header('Content-Type: application/json');
      echo json_encode($response, JSON_PRETTY_PRINT);
    }

    function getUser($id=0)
    {
      global $conn;
      $query = "SELECT * FROM users";
      if($id != 0)
      {
        $query .= " WHERE users_id=".$id." LIMIT 1";
      }
      $response = array();
      $result = mysqli_query($conn, $query);
      while($row = mysqli_fetch_array($result))
      {
        $response[] = $row;
      }
      header('Content-Type: application/json');
      echo json_encode($response, JSON_PRETTY_PRINT);
    }

    function AddUser()
    {
      global $conn;
      $users_name = $_POST["users_name"];
      $users_address = $_POST["users_address"];
      $users_email = $_POST["users_email"];
      $users_password = $_POST["users_password"];
      $users_birthday = $_POST["users_birthday"];
      $user_group = $_POST["user_group"]; //On edit le groupe car dans le cas de notre application, nous sommes admin et pouvons décider des droits à attribuer

      echo $query="INSERT INTO users (users_name, users_address, users_email, users_password, users_birthday, user_group) VALUES ('".$users_name."', '".$users_address."', '".$users_email."', '".$users_password."', '".$users_birthday."', '".$user_group."')";

      if(mysqli_query($conn, $query))
      {
        $response=array(
          'status' => 1,
          'status_message' => 'User ajouté avec succès.'
        );
      }
      else
      {
        $response=array(
          'status' => 0,
          'status_message' => 'ERREUR!.'. mysqli_error($conn)
        );
      }
      header('Content-Type: application/json');
      echo json_encode($response);
    }

    function updateUser($id)
    {
      global $conn;
      $_PUT = array(); //Initialisation du tableau qui contiendra les données reçues
      parse_str(file_get_contents('php://input'), $_PUT);

      $users_name = $_PUT["users_name"];
      $users_address = $_PUT["users_address"];
      $users_email = $_PUT["users_email"];
      $users_password = $_PUT["users_password"];
      $users_birthday = $_PUT["users_birthday"];
      $user_group = $_PUT["user_group"];

      //Requête SQL Update
      $query = "UPDATE users SET users_name='".$users_name."', users_address='".$users_address."', users_email='".$users_email."', users_password='".$users_password."', users_birthday='".$users_birthday."', user_group='".$user_group."' WHERE users_id=".$id;

      if(mysqli_query($conn, $query))
      {
        $response=array(
          'status' => 1,
          'status_message' => 'Produit mis à jour avec succès.'
        );
      }
      else
      {
        $response=array(
          'status' => 0,
          'status_message' =>'Echec de la mise a jour de produit. '. mysqli_error($conn)
        );
        
      }
      header('Content-Type: application/json');
      echo json_encode($response);
    }

    function deleteProduct($id) //!\\Cela ne marche pas sur un utilisateur qui a une VM étant donné que c'est une clé liée, il faut d'abord supprimer la VM avant de supprimer l'user.
    {
      global $conn;
      $query = "DELETE FROM users WHERE users_id=".$id;
      if(mysqli_query($conn, $query))
      {
        $response=array(
          'status' => 1,
          'status_message' =>'Produit supprime avec succes.'
        );
      }
      else
      {
        $response=array(
          'status' => 0,
          'status_message' =>'La suppression du produit a echoue. '. mysqli_error($conn)
        );
      }
      header('Content-Type: application/json');
      echo json_encode($response);
    }

    switch($request_method)
    {
      case 'GET':
        if(!empty($_GET["id"]))
        {
          // Récupérer un seul user
          $id = intval($_GET["id"]);
          getUser($id);
        }
        else
        {
          // Récupérer tous les users
          getUsers();
        }
        break;
      default:
        // Requête invalide
        header("HTTP/1.0 405 Method Not Allowed");
        break;
      
      case 'POST':
        //Ajouter un user
        AddUser();
        break;
      
      case 'PUT':
        //Modifier un user
        $id = intval($_GET["id"]);
        updateUser($id);
        break;
      
      case 'DELETE':
        //Supprimer un user
        $id = intval($_GET["id"]);
        deleteProduct($id);
        break;
    }