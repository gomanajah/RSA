## RSA (Rivest, Shamir, Adleman), Developed in 1977
* Creating public/private keys:

1. Choose two large prime numbers p , q (e.g., 1024 bits each)
2. Compute n = pq,  z = (p-1)(q-1)
3. Choose e (with e<n) that has no common factors with z. (e, z are “relatively prime”).
4. Choose d such that ed-1 is  exactly divisible by z (in other words: ed mod z  = 1 ).
5. `Public key` is (n,e) <PU> and `Private key` is (n,d) <PR>.

**_Encryption:_**
Given public key (n,e) as computed above To encrypt message m (<n), compute: c = m^e mod n

**_Decryption:_**
Given private key (n,d) as computed above To decrypt received bit pattern, c, compute: m = c^d mod n

                                       ** Implementation **
* Help user for public and private key selection:
   - Get 2 prime numbers (p and q) from user.
   - Calculate n and z  (n should be grater than 127).
   - Encrypt each character by using ASCII code of each character (convert to a number).
   - Get e from user ( e<n, and e and z are relatively prime).
   - Choose d automatically such that ed mod z  = 1.
   - Write public key as {e, n}.
   - Write private key as {d, n}.

* Encrypt the given text:
   - Get public key as {e, n} from user.
   - Get text string from user.
   - Encrypt each character by using ASCII code of each character (convert to a number).
   - Write the encrypted text in HEX encoding (4 characters output for each input- put 0 if it is less than 4 chars).
     - For example: Dec: 326  => Hex: 146 => on screen: 0146

* Decrypt the given text:
   - Get private key as {d, n} from user.
   - Get encrypted text string from user as HEX stream.
   - Decrypt each character by using ASCII code of each character (convert to a number).
   - Write the plaintext.

                                       ** Hints **
> c = m^e mod  n
```
c = 1;
for (i=0;i< e;i++)
c=c*m%n;
c = c%n;
```
