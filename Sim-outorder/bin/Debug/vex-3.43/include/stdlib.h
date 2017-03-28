/**
*** static char sccs_id[] = "$Id: stdlib.h,v 1.1.1.1 2001/11/21 20:34:39 frb Exp $ ";
**/
/*
 * stdlib.h
 *
 * Definitions for common types, variables, and functions.
 */

#ifndef _STDLIB_H_
#ifdef __cplusplus
extern "C" {
#endif
#define _STDLIB_H_

#include "_ansi.h"

#define __need_size_t
#define __need_wchar_t
#include <stddef.h>

#include <sys/reent.h>

typedef struct 
{
  int quot; /* quotient */
  int rem; /* remainder */
} div_t;

typedef struct 
{
  long quot; /* quotient */
  long rem; /* remainder */
} ldiv_t;

#ifndef NULL
#define NULL 0
#endif

#define EXIT_FAILURE 1
#define EXIT_SUCCESS 0

#define RAND_MAX 0x7fffffff

#define MB_CUR_MAX 1 

_VOID	_EXFUN(abort,(_VOID) _ATTRIBUTE ((noreturn)));
int	_EXFUN(abs,(int));
#ifndef _STRICT_ANSI
_PTR	_EXFUN(alloca,(size_t _size));
#endif
int	_EXFUN(atexit,(_VOID (*_func)(_VOID)));
double	_EXFUN(atof,(const char *_nptr));
#ifndef _STRICT_ANSI
float	_EXFUN(atoff,(const char *_nptr));
#endif
int	_EXFUN(atoi,(const char *_nptr));
long	_EXFUN(atol,(const char *_nptr));
_PTR	_EXFUN(bsearch,(const _PTR _key,
		       const _PTR _base,
		       size_t _nmemb,
		       size_t _size,
		       int _EXFUN((*_compar),(const _PTR, const _PTR))));
_PTR	_EXFUN(calloc,(size_t _nmemb, size_t _size));
div_t	_EXFUN(div,(int _numer, int _denom));
_VOID	_EXFUN(exit,(int _status) _ATTRIBUTE ((noreturn)));
_VOID	_EXFUN(free,(_PTR));
char *  _EXFUN(getenv,(const char *_string));
long	_EXFUN(labs,(long));
ldiv_t	_EXFUN(ldiv,(long _numer, long _denom));
_PTR	_EXFUN(malloc,(size_t _size));

int	_EXFUN(mblen,(const char *, size_t));
int	_EXFUN(mbtowc,(wchar_t *, const char *, size_t));
int	_EXFUN(wctomb,(char *, wchar_t));
size_t	_EXFUN(mbstowcs,(wchar_t *, const char *, size_t));
size_t	_EXFUN(wcstombs,(char *, const wchar_t *, size_t));
_VOID	_EXFUN(qsort,(_PTR _base, size_t _nmemb, size_t _size, int(*_compar)(const _PTR, const _PTR)));
int	_EXFUN(rand,(_VOID));
_PTR	_EXFUN(realloc,(_PTR _r, size_t _size));
_VOID	_EXFUN(srand,(unsigned _seed));
double	_EXFUN(strtod,(const char *_n, char **_end_PTR));
#ifndef _STRICT_ANSI
float	_EXFUN(strtodf,(const char *_n, char **_end_PTR));
#endif
long	_EXFUN(strtol,(const char *_n, char **_end_PTR, int _base));
unsigned long _EXFUN(strtoul,(const char *_n_PTR, char **_end_PTR, int _base));
unsigned long _EXFUN(_strtoul_r,(struct _reent *,const char *_n_PTR, char **_end_PTR, int _base));
int	_EXFUN(system,(const char *_string));

#ifndef _STRICT_ANSI
_VOID	_EXFUN(cfree,(_PTR, _PTR));
int	_EXFUN(putenv,(const char *_string));
int	_EXFUN(setenv,(const char *_string, const char *_value, int _overwrite));

char *	_EXFUN(gcvt,(double,int,char *));
char *	_EXFUN(gcvtf,(float,int,char *));
char *	_EXFUN(fcvt,(double,int,int *,int *));
char *	_EXFUN(fcvtf,(float,int,int *,int *));
char *	_EXFUN(ecvt,(double,int,int *,int *));
char *	_EXFUN(ecvtbuf,(double, int, int*, int*, char *));
char *	_EXFUN(fcvtbuf,(double, int, int*, int*, char *));
char *	_EXFUN(ecvtf,(float,int,int *,int *));
char *	_EXFUN(dtoa,(double, int, int, int *, int*, char**));
int	_EXFUN(rand_r,(unsigned *_seed));
#endif /* ! _STRICT_ANSI */

char *	_EXFUN(_dtoa_r,(struct _reent *, double, int, int, int *, int*, char**));
_PTR	_EXFUN(_malloc_r,(struct _reent *, size_t));
_PTR	_EXFUN(_calloc_r,(struct _reent *, size_t, size_t));
_VOID	_EXFUN(_free_r,(struct _reent *, _PTR));
_PTR	_EXFUN(_realloc_r,(struct _reent *, _PTR, size_t));
_VOID	_EXFUN(_mstats_r,(struct _reent *, char *));
int	_EXFUN(_system_r,(struct _reent *, const char *));

_VOID	_EXFUN(__eprintf,(const char *, const char *, unsigned int, const char *));


#ifdef __hpux
#ifndef _STRUCT_MALLINFO
#define _STRUCT_MALLINFO
  struct mallinfo  {
        int arena;      /* total space in arena */
        int ordblks;    /* number of ordinary blocks */
        int smblks;     /* number of small blocks */
        int hblks;      /* number of holding blocks */
        int hblkhd;     /* space in holding block headers */
        int usmblks;    /* space in small blocks in use */
        int fsmblks;    /* space in free small blocks */
        int uordblks;   /* space in ordinary blocks in use */
        int fordblks;   /* space in free ordinary blocks */
        int keepcost;   /* cost of enabling keep option */
  };
#endif /* _STRUCT_MALLINFO */
extern struct mallinfo _EXFUN(mallinfo,(void));
#endif /* __hpux */

#ifdef __cplusplus
}
#endif
#endif /* _STDLIB_H_ */
