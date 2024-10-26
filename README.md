Aquí tienes una descripción detallada del proyecto y su objetivo, enfocada para que otro desarrollador pueda comprender el propósito y las funcionalidades de este código.

---

### Descripción del Proyecto

El proyecto consiste en la creación y manipulación de una lista de pólizas de seguro (`PolicyInfo`), cada una asociada con múltiples beneficiarios (`BeneficiaryInfo`). Este proyecto incluye tanto la generación de datos ficticios como la impresión de una tabla estructurada que simula un reporte de pólizas y sus beneficiarios. Adicionalmente, el proyecto incorpora pruebas unitarias para verificar las reglas de negocio en torno a la generación y manejo de los datos de beneficiarios.

#### Componentes Principales

1. **Clases de Dominio**:
   - **`PolicyInfo`**: Representa una póliza de seguro. Contiene propiedades como `Id`, `Name`, y una lista de `BeneficiaryInfo`.
   - **`BeneficiaryInfo`**: Representa a un beneficiario de la póliza. Incluye propiedades como `Id`, `Name`, `Genre` (género) y `RelationShip` (relación con el titular de la póliza).

2. **Servicio de Pólizas (`PolicyService`)**:
   - Este servicio simula la obtención de pólizas desde una base de datos mediante el método `GetPolicies`. 
   - Cada póliza generada contiene un identificador único (`Id`), un nombre aleatorio (`Name`), y una lista de beneficiarios.
   - El servicio `ListaMalBeneficiarios` crea beneficiarios con nombres, géneros y relaciones asignados aleatoriamente, asegurando que el primer beneficiario siempre sea el titular ("COTIZANTE") y que los otros dos beneficiarios tengan relaciones aleatorias como "HIJO", "PADRE" o "MADRE".

3. **Generación de Reporte**:
   - El código genera una tabla que presenta las pólizas y sus beneficiarios en un formato tabular en la consola.
   - Cada fila de la tabla representa una póliza y sus tres beneficiarios.
   - Se utiliza el carácter `|` para separar columnas y calcular el ancho máximo necesario para alinear cada columna de manera precisa.
   - La tabla incluye detalles como `Policy ID`, `Policy Name`, y para cada beneficiario muestra `Beneficiary Name`, `Beneficiary Genre`, y `Beneficiary Relationship`.

4. **Pruebas Unitarias (`PolicyListingTests`)**:
   - Las pruebas unitarias están diseñadas para verificar las reglas de negocio aplicadas a los datos generados.
   - Las pruebas utilizan **Moq** para simular el servicio `IPolicyService` y validar que el método `GetPolicies` devuelva una lista de pólizas que cumplan con las expectativas.
   - Se incluyen pruebas para confirmar que:
     - Cada póliza contiene un beneficiario principal con la relación `"COTIZANTE"`.
     - Al menos uno de los otros beneficiarios tenga una relación distinta, como `"HIJO"`, `"PADRE"`, o `"MADRE"`.
   - Estas pruebas ayudan a asegurar que la lógica de generación de datos en `PolicyService` es consistente con los requisitos.

### Objetivos del Proyecto

1. **Simulación de Datos**:
   - Crear un conjunto de datos ficticios de pólizas y beneficiarios que pueda ser utilizado para pruebas y simulaciones sin depender de una base de datos real.

2. **Visualización Estructurada**:
   - Presentar los datos de pólizas y beneficiarios en una tabla estructurada en la consola, con columnas alineadas y separadores claros que faciliten la legibilidad.

3. **Validación de Reglas de Negocio**:
   - Verificar que los datos generados cumplan con las reglas de negocio establecidas:
     - El primer beneficiario debe ser siempre el titular o "COTIZANTE".
     - Los demás beneficiarios deben tener relaciones aleatorias seleccionadas de una lista limitada de opciones, PADRE, MADRE, HIJO.
   - Las pruebas unitarias aseguran que la lógica implementada en `PolicyService` cumple con estas reglas, detectando cualquier inconsistencia en el modelo de datos generado.

4. **Pruebas Automatizadas para Consistencia**:
   - Asegurar la consistencia y exactitud de la estructura de datos mediante pruebas unitarias. Las pruebas no solo validan la lógica de generación de beneficiarios, sino que también permiten a otros desarrolladores verificar rápidamente que los cambios futuros no rompan las reglas de negocio.

### Casos de Uso

Este proyecto puede ser utilizado para simular la gestión de pólizas de seguro en una aplicación de mayor escala. Los desarrolladores pueden expandir este código para integrarlo en aplicaciones más complejas o utilizar la estructura de prueba para validar servicios de datos en entornos de desarrollo. Además, es una base práctica para probar conceptos de alineación de datos en consola, generación de datos ficticios y pruebas de consistencia.
