/** @file _Person.c
 *  @bug No known bugs.
 */
 
 /* -- Includes -- */
#include <stdio.h>
#include <string.h>	

/**
 * A structure to represent the data of a person
 */
typedef struct _Person
{
 char name[128]; /**< the name */
 char phoneNumber[32]; /**< the phone number */
 int age; /**< the age */
 char sex; /**< the sex */
} Person; 

 /** @brief _Person entrypoint.
 *  
 *  This calculates how much memory is needed.
 *
 * @return Should not return
 */
int main()
{
 printf("The structure allocates in bytes : %d\n", sizeof(Person)); /**< prints a menssage plus the size of the struct * */ 
 return 0;
}
