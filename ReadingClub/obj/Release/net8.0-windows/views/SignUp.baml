   M S B A M L   `   `   `  ����   ReadingClub$    ReadingClub.Controllers.SignUp   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     N�Name$  
SignUpPage�� N� Title$ SignUp��$	��800��$
��1500�� N� 
Background �	#FF263859.���  � ColumnDefinitions �� $��* ��� $��* �.+��� $��0�����	#FF17223B���	#FF17223B�� $��0��$��Center=�$��Center=�.+��� -    ��Name$ textOne��$��Join Us Today!��
�������$��32(�$
��Bold"�$(��"../assets/fonts/#Poppins ExtraBold)� �� TextAlignment$ Center=��� -   $ textTwo��$%��Sign Up now to become a member.��
�������$��18(�$&�� ../assets/fonts/#Poppins Regular)�$ Center=�$��0,20,0,0q��� -    ��Name$
 logo��$	��350��$	��385��$5��/../assets/images/book-club-removebg-preview.png��$��0,20,0,0q��� -   $ 	textThree��$A��;Copyright © 2023 - Created with ❤️ By Amira and Jamil.��
�������$��10(�$&�� ../assets/fonts/#Poppins Regular)�$
��Left=�$��Bottom=�$��	10,0,0,10q�$��0���� $��1��$��Center=�$��Center=� � Cursor$
 Hand��.+��� -   $ textFour��$��SIGNUP��$��20(�$��0,0,0,26q�$(��"../assets/fonts/#Poppins ExtraBold)�$
��Bold"����	#FFFF6768$
 Left=��� -    ��Name$ firstNameLabel��$��
First name��$��16(�$��0,0,0,10q�
�������$&�� ../assets/fonts/#Poppins Regular)�$��0q��� -   	 ��Name$	 firstNameInput��$��4,0,4,0q�$	��450��$��40�����	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)����	#7FFFFFFF$��16(�$��Center=��� -	   $ firstNameErrorLabel��$��12(����#F31559$�� ��$&�� ../assets/fonts/#Poppins Regular)�$��26���� -
   $ lastNameLabel��$��	Last name��$��16(�$��0,0,0,10q�
�������$&�� ../assets/fonts/#Poppins Regular)�$��0q��� -   $	 lastNameInput��$��4,0,4,0q�$	��450��$��40�����	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)����	#7FFFFFFF$��16(�$��Center=��� -   $ lastNameErrorLabel��$��12(����#F31559$�� ��$&�� ../assets/fonts/#Poppins Regular)�$��26���� -   $ 
emailLabel��$��Email��$��16(�$��0,0,0,10q�
�������$&�� ../assets/fonts/#Poppins Regular)�$��0q��� -   $	 
emailInput��$��4,0,4,0q�$	��450��$��40�����	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)����	#7FFFFFFF$��16(�$��Center=��� -   $ emailErrorLabel��$��12(����#F31559$�� ��$&�� ../assets/fonts/#Poppins Regular)�$��26���� -   $ userNameLabel��$��Username��$��16(�$��0,0,0,10q�
�������$&�� ../assets/fonts/#Poppins Regular)�$��0q��� -   $	 userNameInput��$��4,0,4,0q�$	��450��$��40�����	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)����	#7FFFFFFF$��16(�$��Center=��� -   $ usernameErrorLabel��$��12(����#F31559$�� ��$&�� ../assets/fonts/#Poppins Regular)�$��26���� -   $ passwordLabel��$��Password��$��16(�$��0,0,0,10q�
�������$&�� ../assets/fonts/#Poppins Regular)�$��0q�G� -   
 G�Name$
 passwordIput��$��4,0,4,0q�$	��450��$��40�����	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)����	#7FFFFFFF$��16(�$��Center=��� -   $ passwordErrorLabel��$��12(����#F31559$�� ��$&�� ../assets/fonts/#Poppins Regular)�$��0,0,0,10q�$��26���� -    ��Name$ 	signupBtn��$��Sign Up��$��0,0,0,10q�$	��450��$��40�����	#FFFF6768
����������	#FFFF6768$&�� ../assets/fonts/#Poppins Regular)�$��16(� J� OpacityMask �	#FFFF6768$
 Hand���� -   $ haveAccount��$'��!Already have an account ? Sign In��
�������$��16(�$&�� ../assets/fonts/#Poppins Regular)�$ Center=�$
 Hand��