   M S B A M L   `   `   `  ����  ReadingClub$    ReadingClub.Controllers.SignUp   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          N�Name$  
SignUpPage��5       N� Title$ SignUp��5   	   $	��800��6   $
��1500��6(    N� 
Background �	#FF263859.��5      �  � ColumnDefinitions 5	   
   �� 5
      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���	#FF17223B���	#FF17223B67   �� 5   
   $��0��6   $��Center=�6%   $��Center=�6@   .+�5      �� -   5         ��Name$ textOne��5      $��Join Us Today!��6)   
�������$��32(�6R   $
��Bold"�6`   $(��"../assets/fonts/#Poppins ExtraBold)�6r    �� TextAlignment$ Center=�6�   �� 5      -   5        $ textTwo��5      $%��Sign Up now to become a member.��6)   
�������$��18(�6c   $&�� ../assets/fonts/#Poppins Regular)�6q   $ Center=�6�   $��0,20,0,0q�6�   �� 5      -   5         ��Name$
 logo��5      $	��350��6"   $	��385��6/   $5��/../assets/images/book-club-removebg-preview.png��6;   $��0,20,0,0q�6t   5      �� 5   
   -   5        $ 	textThree��5      $A��;Copyright © 2023 - Created with ❤️ By Amira and Jamil.��6'   
�������$��10(�5   '   $&�� ../assets/fonts/#Poppins Regular)�65   $
��Left=�5      $��Bottom=�6/   $��	10,0,0,10q�5      $��0��6'   �� 5   
   $��1��6   $��Center=�6%   $��Center=�6@    � Cursor$
 Hand��6]   .+�5      �� -   5        $ textFour��5      $��SIGNUP��6*   $��20(�68   $��0,0,0,26q�6F   $(��"../assets/fonts/#Poppins ExtraBold)�6X   $
��Bold"�6�   ���	#FFFF6768$
 Left=�6�   �� 5      -   5         ��Name$ firstNameLabel��5      $��
First name��6,   $��16(�6A   $��0,0,0,10q�6O   
�������$&�� ../assets/fonts/#Poppins Regular)�6t   $��0q�6�   �� 5      -   5        	 ��Name$	 firstNameInput��5      $��4,0,4,0q�6.   $	��450��6A   $��40��6M   ���	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)�6�   ���	#7FFFFFFF$��16(�6�   $��Center=�6�   �� 5      -	   5        $ firstNameErrorLabel��5      $��12(�61   ���#F31559$�� ��6T   $&�� ../assets/fonts/#Poppins Regular)�6`   $��26��6�   �� 5      -
   5        $ lastNameLabel��5      $��	Last name��6+   $��16(�6?   $��0,0,0,10q�6M   
�������$&�� ../assets/fonts/#Poppins Regular)�6r   $��0q�6�   �� 5       -   5        $	 lastNameInput��5       $��4,0,4,0q�6-   $	��450��6@   $��40��6L   ���	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)�6�   ���	#7FFFFFFF$��16(�6�   $��Center=�6�   �� 5!      -   5        $ lastNameErrorLabel��5!      $��12(�60   ���#F31559$�� ��6S   $&�� ../assets/fonts/#Poppins Regular)�6_   $��26��6�   �� 5"      -   5        $ 
emailLabel��5"      $��Email��6(   $��16(�68   $��0,0,0,10q�6F   
�������$&�� ../assets/fonts/#Poppins Regular)�6k   $��0q�6�   �� 5#      -   5        $	 
emailInput��5#      $��4,0,4,0q�6+   $	��450��6=   $��40��6I   ���	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)�6�   ���	#7FFFFFFF$��16(�6�   $��Center=�6�   �� 5$      -   5        $ emailErrorLabel��5$      $��12(�6-   ���#F31559$�� ��6P   $&�� ../assets/fonts/#Poppins Regular)�6\   $��26��6�   �� 5%      -   5        $ userNameLabel��5%      $��Username��6+   $��16(�6>   $��0,0,0,10q�6L   
�������$&�� ../assets/fonts/#Poppins Regular)�6q   $��0q�6�   �� 5&      -   5        $	 userNameInput��5&      $��4,0,4,0q�6-   $	��450��6@   $��40��6L   ���	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)�6�   ���	#7FFFFFFF$��16(�6�   $��Center=�6�   �� 5'      -   5        $ usernameErrorLabel��5'      $��12(�60   ���#F31559$�� ��6S   $&�� ../assets/fonts/#Poppins Regular)�6_   $��26��6�   �� 5(      -   5        $ passwordLabel��5(      $��Password��6+   $��16(�6>   $��0,0,0,10q�6L   
�������$&�� ../assets/fonts/#Poppins Regular)�6q   $��0q�6�   G� 5)      -   5        
 G�Name$
 passwordIput��5)      $��4,0,4,0q�61   $	��450��6C   $��40��6O   ���	#3D6B778D���	#3D6B778D$&�� ../assets/fonts/#Poppins Regular)�6�   ���	#7FFFFFFF$��16(�6�   $��Center=�6�   �� 5*      -   5        $ passwordErrorLabel��5*      $��12(�60   ���#F31559$�� ��6S   $&�� ../assets/fonts/#Poppins Regular)�6_   $��0,0,0,10q�6�   $��26��6�   �� 5+      -   5         ��Name$ 	signupBtn��5+      $��Sign Up��6(   $��0,0,0,10q�6:   $	��450��6L   $��40��6X   ���	#FFFF6768
����������	#FFFF6768$&�� ../assets/fonts/#Poppins Regular)�6�   $��16(�6�    J� OpacityMask �	#FFFF6768$
 Hand��6�   6  �� 5,      -   5        $ haveAccount��5,      $'��!Already have an account ? Sign In��6-   
�������$��16(�6i   $&�� ../assets/fonts/#Poppins Regular)�6w   $ Center=�6�   $
 Hand��6�   6�   5.      50      51      