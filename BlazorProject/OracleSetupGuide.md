# Oracle Database Connection Setup Guide

## Prerequisites

### 1. Oracle Database Installation
- **Oracle XE (Express Edition)** - Free version
- **Oracle Developer VM** - Pre-configured virtual machine
- **Oracle Cloud** - Free tier available

### 2. Common Oracle Connection Issues

#### Issue 1: Oracle Service Not Running
```cmd
# Check if Oracle services are running
services.msc
# Look for: OracleServiceXE, OracleXETNSListener
```

#### Issue 2: TNS Listener Not Started
```cmd
# Start TNS Listener
lsnrctl start

# Check listener status
lsnrctl status
```

#### Issue 3: Wrong Port or Service Name
```cmd
# Check which services are available
lsnrctl services
```

## Connection String Formats

### Format 1: EZ Connect (Simplest)
```
Data Source=localhost:1521/XE;User Id=username;Password=password;
```

### Format 2: TNS Format
```
Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=username;Password=password;
```

### Format 3: With SID instead of Service Name
```
Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=XE)));User Id=username;Password=password;
```

## Testing Oracle Connection

### Using SQL*Plus
```cmd
sqlplus username/password@localhost:1521/XE
```

### Using TNS Ping
```cmd
tnsping localhost:1521
```

## Common Default Values
- **Port**: 1521
- **Service Name**: XE (for Express Edition)
- **SID**: XE (for Express Edition)
- **Default Username**: HR, SYSTEM, SYS
- **PDB Name**: XEPDB1 (for newer versions)

## Troubleshooting Steps

1. **Verify Oracle is installed and running**
2. **Check Windows Services** for Oracle services
3. **Test with SQL*Plus** first
4. **Check firewall settings** for port 1521
5. **Verify username/password** in Oracle
6. **Check if using PDB** (Pluggable Database) vs regular database