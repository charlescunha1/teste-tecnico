package com.Transactions.Transactions.Repository;

import java.time.LocalDateTime;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import com.Transactions.Transactions.Entity.Transactions;
import com.Transactions.Transactions.Enum.Type;

@Repository
public interface TransactionsRepository extends JpaRepository<Transactions, Integer> {
    List<Transactions> findByCounterpartyAccountNumberAndCounterpartyBankCode(String counterpartyAccountNumber, String counterpartyBankCode);
    List<Transactions> findAllByTypeOrderByCreatedAtDesc(Type type);
    List<Transactions> findAllByTypeAndCreatedAtAfterOrderByCreatedAtDesc(Type type, LocalDateTime createdAtAfter);
    List<Transactions> findAllByCreatedAtAfterOrderByCreatedAtDesc(LocalDateTime createdAtAfter);
    List<Transactions> findAllByOrderByCreatedAtDesc();
}
