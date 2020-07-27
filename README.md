# ClientServer
Client server Architecture to transfer Object from one process to another process using RemoteObject

# Server:
Open the ClientServerObject.exe
Click the Open server button, then it will open open port 8085 with Remote Object.
After successful create object the button will be disabled

# Client:
Open ClientObject.exe

After successful create object the button will be disabled
Click connect to server button to connect the server
After successful connect with created object the button will be disabled

# Send Message:
After successful connect now you can send message to each other, I have added Object as parameter, so user can send any object.
But those must be in LibClientServer Dll like ModelRemoteObject with [Serializable] and inherited from MarshalByRefObject
